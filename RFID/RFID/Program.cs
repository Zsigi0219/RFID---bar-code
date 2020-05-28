using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID
{
    class Program
    {
        static List<IdentificationTechnology> ReadInput(string inputFileName)
        {
            List<IdentificationTechnology> technologies = new List<IdentificationTechnology>();

            StreamReader reader = null;
            string[] tokens;

            try
            {
                reader = new StreamReader(inputFileName);
                while (!reader.EndOfStream)
                {
                    tokens = reader.ReadLine().Split(';');
                    switch (tokens.Length)
                    {
                        case 1:
                            technologies.Add(new BarCode(
                                                    ulong.Parse(tokens[0])
                                                    ));
                            break;
                        case 4:
                            technologies.Add(new PassiveRFID(
                                                    ulong.Parse(tokens[0]),
                                                    (FrequencyType)Enum.Parse(typeof(FrequencyType), tokens[1]),
                                                    bool.Parse(tokens[2]),
                                                    bool.Parse(tokens[3])
                                                    ));
                            break;
                        case 5:
                            technologies.Add(new ActiveRFID(
                                                    ulong.Parse(tokens[0]),
                                                    (FrequencyType)Enum.Parse(typeof(FrequencyType), tokens[1]),
                                                    bool.Parse(tokens[2]),
                                                    bool.Parse(tokens[3]),
                                                    (BatteryType)Enum.Parse(typeof(BatteryType), tokens[4])
                                                    ));
                            break;
                        default:
                            throw new ArgumentException("A txt fájl sora nem megfelelő hosszú");
                    }
                }
            }
            // KÜLÖNBÖZŐ KIVÉTELEK KEZELÉSE!!!
            catch (FileNotFoundException e)
            {
                Console.WriteLine("A {0} fájl nem található!", e.FileName);
            }
            catch (IdSetException e)
            {
                Console.WriteLine("A {0} beállítása nem sikerült", e.Id);
            }
            catch (ScanException e)
            {
                Console.WriteLine("A {0} szkennelése nem sikerült ebben az időpontban: {1}", e.Id, e.Time);
            }
            catch (Exception e)
            {
                Console.WriteLine("Egyéb hiba történt: {0}", e.Message);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

            return technologies;
        }

        static void Main(string[] args)
        {
            List<IdentificationTechnology> technologies = ReadInput("id_techs.txt");

            Random rnd = new Random();
            for (int i = 0; i < 8; i++)
            {
                try
                {
                    IdentificationTechnology tech = technologies[rnd.Next(technologies.Count)];

                    if (tech is IScannable)
                        (tech as IScannable).StartScan((float)rnd.NextDouble() * 300);

                    Console.WriteLine("Olvasott ID: {0}", tech.Id);
                    int newId = rnd.Next();
                    Console.WriteLine("Új ID-t írok: {0}", newId);
                    tech.Id = (ulong)newId;

                    if (tech is IScannable)
                        (tech as IScannable).StopScan((float)rnd.NextDouble() * 300);
                }
                // KÜLÖNBÖZŐ KIVÉTELEK KEZELÉSE!!!
                catch (IdSetException e)
                {
                    Console.WriteLine("A {0} beállítása nem sikerült", e.Id);
                }
                catch (ScanException e)
                {
                    Console.WriteLine("A {0} szkennelése nem sikerült ebben az időpontban: {1}", e.Id, e.Time);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Egyéb hiba történt: {0}", e.Message);
                }
            }

            // LISTAELEMEK KIÍRATÁSA

            Console.ReadKey();
        }
    }
}
