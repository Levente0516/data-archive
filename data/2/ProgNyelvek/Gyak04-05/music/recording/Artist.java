package music.recording;

public class Artist
{
    private final String name;
    private final RecordLabel label;

    public Artist(String n, RecordLabel l)
    {
        this.name = n;
        this.label = l;
    }

    public String getName()
    {
        return this.name;
    }

    public RecordLabel getLabel()
    {
        return this.label;
    }

}