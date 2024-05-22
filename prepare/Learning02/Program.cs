using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Electrical Engineer";
        job1._company = "Lockheed Martin";
        job1._startYear = 2030;
        job1._endYear = 2040;

        Job job2 = new Job();
        job2._jobTitle = "Space engineer";
        job2._company = "Nasa";
        job2._startYear = 2045;
        job2._endYear = 2055;

         Resume myResume = new Resume();
        myResume._name = "Kaleb Watts";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        myResume.Display();
    }
}