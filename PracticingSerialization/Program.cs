
using PracticingSerialization;
using System.Xml.Serialization;

namespace PracticingSerialization
{
    public class Program
    {
        static void Main(string[] args)
        {

            var theRadio = new Radio
            {
                StationPresets = new() { 89.3, 105.1, 97.1 },
                HasTweeters = true
            };
            // Make a JamesBondCar and set state.
            JamesBondCar jbc = new()
            {
                CanFly = true,
                CanSubmerge = false,
                TheRadio = new()
                {
                    StationPresets = new() { 89.3, 105.1, 97.1 },
                    HasTweeters = true
                }
            };
            List<JamesBondCar> myCars = new()
            {
             new JamesBondCar { CanFly = true, CanSubmerge = true, TheRadio = theRadio },
             new JamesBondCar { CanFly = true, CanSubmerge = false, TheRadio = theRadio },
             new JamesBondCar { CanFly = false, CanSubmerge = true, TheRadio = theRadio },
             new JamesBondCar { CanFly = false, CanSubmerge = false, TheRadio = theRadio },
            };
            Person p = new Person
            {
                FirstName = "James",
                IsAlive = true
            };


            SaveAsXmlFormat(jbc, "CarData.xml");
            Console.WriteLine("=> Saved car in XML format!");
            SaveAsXmlFormat(p, "PersonData.xml");
            Console.WriteLine("=> Saved person in XML format!");
            Console.WriteLine("***** Fun with Object Serialization *****\n");
        }
        static void SaveAsXmlFormat<T>(T objGraph, string fileName)
        {
            //Must declare type in the constructor of the XmlSerializer
            XmlSerializer xmlFormat = new XmlSerializer(typeof(T));
            using (Stream fStream = new FileStream(fileName,
            FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, objGraph);
            }
        }

    }
}