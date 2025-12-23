package parking.facility;

import java.util.ArrayList;
import parking.ParkingLot;
import vehicle.Car;
import parking.facility.Space;
import vehicle.Size;
import java.util.*;

public class Gate
{
    private final ArrayList<Car> cars;
    private final ParkingLot parkingLot;
    public Space helperAdattagMivelEnelkulNemTudomMegcsinalni;

    public Gate(ParkingLot parkingLot)
    {
        this.parkingLot = parkingLot;
        this.cars = new ArrayList<>();
    }

    private Space findTakenSpaceByCar(Car c)
    {
        Space[][] floorPlan = parkingLot.getFloorPlan();
        for (int i = 0; i < floorPlan.length; i++)
        {
            for (int j = 0; j < floorPlan[i].length; j++)
            {
                if (!floorPlan[i][j].isTaken())
                {
                    if (floorPlan[i][j].getCarLicensePlate() == c.getLicensePlate())
                    {
                        return floorPlan[i][j];
                    }
                }
            }
        }

        return null;
    }

    private Space findAvailableSpaceOnFloor(int floor, Car c)
    {
        Space[][] floorPlan = parkingLot.getFloorPlan();
        for (int i = 0; i < floorPlan.length; i++)
        {
            if (i == floor)
            {
                for (int j = 0; j < floorPlan[i].length; j++)
                {
                    if (c.getSpotOccupation() == Size.SMALL && !floorPlan[i][j].isTaken())
                    {
                        return floorPlan[i][j];
                    }
                    if (c.getSpotOccupation() == Size.LARGE && !floorPlan[i][j].isTaken() && j+1 < floorPlan[i].length && !floorPlan[i][j+1].isTaken())
                    {
                        helperAdattagMivelEnelkulNemTudomMegcsinalni = floorPlan[i][j+1];
                        return floorPlan[i][j];
                    }
                }
            }
        }

        return null;
    }

    public Space findAnyAvailableSpaceForCar(Car c)
    {
        for (int floor = 0; floor < parkingLot.getFloorPlan().length; floor++)
        {
            Space space = findAvailableSpaceOnFloor(floor, c);
            if (space != null)
            {
                return space;
            }
        }

        return null;
    }

    public Space findPreferredAvailableSpaceForCar(Car c)
    {
        int preferredFloor = c.getPreferredFloor();

        for (int i = preferredFloor; i >= 0; i--)
        {
            Space space = findAvailableSpaceOnFloor(i, c);
            if(space != null)
            {
                return space;
            }
        }

        return null;
    }

    public boolean registerCar(Car c)
    {
        Space space = findPreferredAvailableSpaceForCar(c);

        if(space == null)
        {
            space = findAnyAvailableSpaceForCar(c);
        }

        if (space != null)
        {
            space.addOccupyingCar(c);
            c.setTicketId(UUID.randomUUID().toString());
            if (c.getSpotOccupation() == Size.LARGE)
            {
                space = helperAdattagMivelEnelkulNemTudomMegcsinalni;
                space.addOccupyingCar(c);
            }
            return true;
        }

        return false;
    }

    public void registerCars(Car... cars)
    {
        for (int i = 0; i < cars.length; i++)
        {
            boolean l = registerCar(cars[i]);
            if (!l)
            {
                System.out.println("Nincs szabad hely az autonak");
            }
        }
    }

    public void deRegisterCar(String ticketId)
    {
        Space[][] floorPlan = parkingLot.getFloorPlan();

        for (int i = 0; i < floorPlan.length; i++)
        {
            for (int j = 0; j < floorPlan[i].length; j++)
            {
                if (floorPlan[i][j].isTaken())
                {
                    String licensePlate = floorPlan[i][j].getCarLicensePlate();

                    for (Car car : cars)
                    {
                        if (car.getLicensePlate().equals(licensePlate) && car.getTicketId().equals(ticketId))
                        {
                            if (floorPlan[i][j].getOccupyingCarSize() == Size.LARGE)
                            {
                                floorPlan[i][j].removeOccupyingCar();
                                floorPlan[i][j+1].removeOccupyingCar();
                            }

                            if (floorPlan[i][j].getOccupyingCarSize() == Size.SMALL)
                            {
                                floorPlan[i][j].removeOccupyingCar();
                            }
                        }
                    }
                }
            }
        }
    }
}