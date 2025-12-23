package music.recording;

public class RecordLabel
{
    private final String name;

    public String getName()
    {
        return this.name;
    }

    private int cash;

    public int getCash()
    {
        return this.cash;
    }

    public RecordLabel(String n, int c)
    {
        this.name = n;
        this.cash = c;
    }

    public void gotIncome(int n)
    {
        cash += n; 
    }
}