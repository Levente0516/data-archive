package race.car;

public class WrongSectorTimer1 {
    public int[] times;

    public WrongSectorTimer1(int[] times) {
        this.times = times;
    }

    public boolean seemsGood() {
        return times.length == 3 && times[0] == 1 && times[1] == 2 && times[2] == 3;
    }

    public void setArrayElemsBreaksEncapsulation() {
        times[0] = 10;
        times[1] = 20;
        times[2] = 30;
    }

    public void replaceArrayCompletely() {
        times = new int[]{100, 200};
    }
}