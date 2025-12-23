package parking.facility;

import static org.junit.jupiter.api.Assertions.*;
import static check.CheckThat.*;
import org.junit.jupiter.api.*;
import org.junit.jupiter.params.*;
import org.junit.jupiter.params.provider.*;
import check.*;

import parking.facility.Gate;
import parking.facility.Space;
import vehicle.Car;
import vehicle.Size;
import parking.ParkingLot;

public class GateTest
{
    private ParkingLot floorPlan;
    private Gate gate;
    private Car smallCar;
    private Car largeCar;

    @BeforeEach
    public void setup()
    {
        floorPlan= new ParkingLot(3,3);
        gate = new Gate(floorPlan);

        smallCar = new Car("CAR-001", Size.SMALL, 0);
        largeCar = new Car("CAR-002", Size.LARGE, 1);

        smallCar.setTicketId("S");
        largeCar.setTicketId("L");
    }
    
    @Test
    public void testFindAnyAvailableSpaceForCar()
    {
        Space test1 = gate.findAnyAvailableSpaceForCar(smallCar);
        assertNotNull(test1);
        assertEquals(0, test1.getFloorNumber());
        assertEquals(0, test1.getSpaceNumber());

        test1.addOccupyingCar(smallCar);
        gate.registerCar(smallCar); 

        Space test2 = gate.findAnyAvailableSpaceForCar(largeCar);

        assertNotNull(test2);
        assertEquals(1, test2.getFloorNumber());
        assertEquals(0, test2.getSpaceNumber());

        gate.deRegisterCar(smallCar.getTicketId());
    }

    @ParameterizedTest
    @CsvSource({
        "CAR-003, SMALL, 0",
        "CAR-004, LARGE, 1"
    })
    public void testFindPreferredAvailableSpaceForCar(String plate, Size size, int preferredFloor)
    {
        Car car = new Car(plate, size, preferredFloor);
        car.setTicketId("C1");

        Space test3 = gate.findPreferredAvailableSpaceForCar(car);
        
        gate.registerCar(car);

        assertNotNull(test3);
    }

    @ParameterizedTest
    @CsvSource({
        "CAR-005, SMALL, 0",
        "CAR-006, LARGE, 1"
    })
    public void testRegisterCar(String plate, Size size, int preferredFloor)
    {
        Car car2 = new Car(plate, size, preferredFloor);
        car2.setTicketId("C2");

        boolean mukodik = gate.registerCar(car2);

        assertEquals(true, mukodik);
    }

    @ParameterizedTest
    @CsvSource({
        "CAR-007, SMALL, 0",
        "CAR-008, LARGE, 1"
    })
    public void testDeRegisterCar(String plate, Size size, int preferredFloor)
    {
        Car car3 = new Car(plate, size, preferredFloor);
        car3.setTicketId("C3");

        gate.registerCar(car3);

        gate.deRegisterCar("C3");

        boolean found = false;

        Space[][] floor = floorPlan.getFloorPlan();

        for (int i = 0; i < floor.length; i++)
        {
            for (int j = 0; j < floor[i].length; j++)
            {
                if (floor[i][j] != null)
                {
                    found = true;
                }
            }
        }

        assertTrue(found, "Hiba");
    }
}