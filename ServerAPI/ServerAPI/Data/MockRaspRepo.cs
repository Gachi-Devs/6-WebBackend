using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ServerAPI.Data
{
    public class MockRaspRepo : IRaspRepo
    {

        string path = "P:/ITheM/Documents/TESTJSON2";

        public IEnumerable<MRaspisanie> GetAllRasp()
        {
            var rasps = new List<MRaspisanie>();
            int index = new DirectoryInfo($"{path}").GetFiles().Length;
            for (int i = 0; i < index; i++)
            {
                rasps.Add(JsonConvert.DeserializeObject<MRaspisanie>(File.ReadAllText($"{path}/DATA{i+1}.json")));
            }
            
            
            
            return rasps;
        }

        public MRaspisanie GetRaspById(int id)
        {
            var rasp = File.Exists($"{path}/DATA{id}.json") ?
                JsonConvert.DeserializeObject<MRaspisanie>(File.ReadAllText($"{path}/DATA{id}.json")) : new MRaspisanie()
                {
                    faculty = "null",
                    formOfEdu = "null",
                    cource = "null",
                    weekId = "null",
                    group = new Group[]
                {
                    new Group()
                    {
                        groupName = "null",
                        week = new DayOfWeek[]
                        {
                            new DayOfWeek()
                            {
                                dayName = "null",
                                date = "null",
                                couples = new Couples[]
                                {
                                    new Couples()
                                    {
                                        time = "null",
                                        discipline = "null",
                                        otherInfo = "null"
                                    },
                                    new Couples()
                                    {
                                        time = "null2",
                                        discipline = "null2",
                                        otherInfo = "null"
                                    }
                                }
                            },
                            new DayOfWeek()
                            {
                                dayName = "null2",
                                date = "null",
                                couples = new Couples[]
                                {
                                    new Couples()
                                    {
                                        time = "null",
                                        discipline = "null",
                                        otherInfo = "null"
                                    },
                                    new Couples()
                                    {
                                        time = "null2",
                                        discipline = "null2",
                                        otherInfo = "null"
                                    }
                                }
                            }
                        }
                    },
                    new Group
                    {
                        groupName = "null2",
                        week = new DayOfWeek[]
                        {
                            new DayOfWeek()
                            {
                                dayName = "null",
                                date = "null",
                                couples = new Couples[]
                                {
                                    new Couples()
                                    {
                                        time = "null",
                                        discipline = "null",
                                        otherInfo = "null"
                                    },
                                    new Couples()
                                    {
                                        time = "null2",
                                        discipline = "null2",
                                        otherInfo = "null"
                                    }
                                }
                            },
                            new DayOfWeek()
                            {
                                dayName = "null2",
                                date = "null",
                                couples = new Couples[]
                                {
                                    new Couples()
                                    {
                                        time = "null",
                                        discipline = "null",
                                        otherInfo = "null"
                                    },
                                    new Couples()
                                    {
                                        time = "null2",
                                        discipline = "null2",
                                        otherInfo = "null"
                                    }
                                }
                            }
                        }
                    }
                }
                };
            
            return rasp;
          // return new MRaspisanie(){id = 000, faculty = "Null", formOfEdu = "Null", course = 0, group = "Null"};
        }
    }
    
}