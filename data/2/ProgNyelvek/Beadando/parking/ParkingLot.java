package parking;

import parking.facility.Space;

public class ParkingLot
{
    private final Space[][] floorPlan;

    public Space[][] getFloorPlan()
    {
        return floorPlan;
    }

    public ParkingLot(int floorNumber, int spaceNumber)
    {
        if (floorNumber <= 0 || spaceNumber <= 0) 
        {
            throw new IllegalArgumentException();
        }

        floorPlan = new Space[floorNumber][spaceNumber];

        for (int i = 0; i < floorNumber; i++)
        {
            for (int j = 0; j < spaceNumber; j++)
            {
                floorPlan[i][j] = new Space(i,j);
            }
        }
    }

    @Override
    public String toString()
    {
        StringBuilder sb = new StringBuilder();

        Space floorPlan[][] = getFloorPlan();

        for (int i = floorPlan.length - 1; i >= 0; i--)
        {
            for (int j = 0; j < floorPlan[i].length; j++)
            {
                if (!floorPlan[i][j].isTaken())
                {
                    sb.append("X");
                }
                else
                {
                    switch(floorPlan[i][j].getOccupyingCarSize())
                    {
                        case SMALL:
                            sb.append("S");
                            break;
                        case LARGE:
                            sb.append("L");
                            break;
                    }
                }

                sb.append(" ");
            }

            sb.append("\n");
        }

        return sb.toString();
    }
}