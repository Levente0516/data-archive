package race.car;

public class WrongSectorTimer2 {
    private int[] times;

    public WrongSectorTimer2(int[] times) {
        this.times = times;
    }

    public int[] getSectorTimes() {
        return times;
    }

    public void setSectorTimes(int[] times) {
        this.times = times;
    }

    public boolean seemsGood() {
        return times.length == 3 && times[0] == 1 && times[1] == 2 && times[2] == 3;
    }
}