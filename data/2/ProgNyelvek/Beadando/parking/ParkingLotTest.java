package parking;

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

public class ParkingLotTest
{
    @Test
    public void testConstructorWithInvalidValues()
    {
        assertThrows(IllegalArgumentException.class, () -> new ParkingLot(-10, 5));
        assertThrows(IllegalArgumentException.class, () -> new ParkingLot(3, -4));
        assertThrows(IllegalArgumentException.class, () -> new ParkingLot(0, 0));
    }

    @Test
    public void testTextualRepresentation()
    {
        ParkingLot a = new ParkingLot(2,2); //a00 a01
        Gate gate = new Gate(a);            //a10 a11 

        Car a00 = new Car("CAR-001", Size.SMALL, 0);
        Car a10a11 = new Car("CAR-002", Size.LARGE, 1);

        a00.setTicketId("T-1");
        a10a11.setTicketId("T-2");

        gate.registerCar(a00);
        gate.registerCar(a10a11);

        Space[][] floorPlan = a.getFloorPlan();

        String expected = 
        "L L \n" +  
        "S X \n";

        assertEquals(expected, a.toString());
    }
}