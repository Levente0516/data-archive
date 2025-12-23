package worker.schedule;

import java.util.Map.Entry;
import java.util.*;

public class WorkerSchedule
{
    HashMap<Integer, HashSet<String>>weekToWorkers;

    public WorkerSchedule()
    {
        weekToWorkers = new HashMap<>();
    }

    public void add(int week, HashSet<String> workers)
    {
        if(!weekToWorkers.containsKey(week))
        {
            weekToWorkers.put(week, workers);
        } 
        else
        {
            weekToWorkers.get(week).addAll(workers);
        }
    }

    public void add(HashSet<Integer>weeks, ArrayList<String>workers)
    {
        HashSet<String> workersSet = new HashSet<>();

        for (String worker : workers)
        {
            workersSet.add(worker);
        }

        for (Integer week : weeks)
        {
            add(week, workersSet);
        }
    }

    public boolean isWorkingOnWeek(String worker, int day)
    {
        return weekToWorkers.containsKey(day) && weekToWorkers.get(day).contains(worker);
    }

    public HashSet<Integer> getWorkWeeks(String worker)
    {
        HashSet<Integer> weeks = new HashSet<>();

        for(Map.Entry<Integer, HashSet<String>> workweek : weekToWorkers.entrySet())
        {
            if(workweek.getValue().contains(worker))
            {
                weeks.add(workweek.getKey());
            }
        }

        return weeks;
    }
}