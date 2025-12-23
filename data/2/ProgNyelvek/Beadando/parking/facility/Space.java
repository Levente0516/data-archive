package parking.facility;

import vehicle.Car;
import vehicle.Size;

public class Space
{
    private final int floorNumber;
    private final int spaceNumber;
    private Car occupyingCar;

    public int getFloorNumber()
    {
        return floorNumber;
    }

    public int getSpaceNumber()
    {
        return spaceNumber;
    }

    public Space(int floorNumber, int spaceNumber)
    {
        this.floorNumber = floorNumber;
        this.spaceNumber = spaceNumber;
    }

    public boolean isTaken()
    {
        return occupyingCar != null;
    }

    public void addOccupyingCar(Car c)
    {
        occupyingCar = c;
    }

    public void removeOccupyingCar()
    {
        occupyingCar = null;
    }

    public String getCarLicensePlate() {
        return (occupyingCar != null) ? occupyingCar.getLicensePlate() : null;
    }

    public Size getOccupyingCarSize() {
        return (occupyingCar != null) ? occupyingCar.getSpotOccupation() : null;
    }
}