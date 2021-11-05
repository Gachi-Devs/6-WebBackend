using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaspFactory.Parser
{


    class Parser
    {

        public string xmlFile { get; private set; }

        public void Pars()
        {
            string xmlFile = "";
            string path = "P:\\ITheM\\Documents\\TESTJSON\\XML.xml";
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(path);
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    Console.WriteLine(line);
                    xmlFile += line;
                    //Read the next line
                    line = sr.ReadLine();

                }
                //close the file
                sr.Close();
                //Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }


            Console.WriteLine("-----------------------------------------------");

            var Config = JsonConvert.DeserializeObject<Configuration.Models.ConfigModel>(File.ReadAllText(@"R:\Документы\JetBrains_C#\RaspFactory\RaspFactory\Configuration\Config.json"));
            string pathToEndFiles = Config.path;


            //int findex = 228;
            string[] sheet = xmlFile.Split("<sheet name=");
            for (int i = 1; i < sheet.Length; i++)
            {

                
              /*  var _mrasp = new List<MRaspisanie>();
                var _groups = new List<Group>();
                var _weekdays = new List<DayOfWeek>();
                var _listOfWeekDays = new List<List<DayOfWeek>>();
                var _couples = new List<Couples>();
                var _listOfCouples = new List<List<Couples>>();
                var _listOfListOfCouples = new List<List<List<Couples>>>();

                MRaspisanie file = new MRaspisanie();
               // string fileName = "DATA";//Сделать id файла
                bool isFCFull = false;
                bool isGroupsFull = false;
                bool isCourceFind = false;*/



                string[] meshIndexOfWeek = sheet[i].Split("<cell>День недели");

                string[] indexOfWeek = new string[meshIndexOfWeek.Length];
                for(int miow = 0; miow < indexOfWeek.Length; miow++)
                {
                    if(miow == 0 || miow == indexOfWeek.Length - 1)
                    {
                        indexOfWeek[miow] = meshIndexOfWeek[miow];
                        continue;
                    }
                    indexOfWeek[miow] = meshIndexOfWeek[miow].Remove(meshIndexOfWeek[miow].LastIndexOf("</row><row>"));
                }


                for (int iow = 1; iow < indexOfWeek.Length; iow++)
                {



                    var _mrasp = new List<MRaspisanie>();
                    var _groups = new List<Group>();
                    var _weekdays = new List<DayOfWeek>();
                    var _listOfWeekDays = new List<List<DayOfWeek>>();
                    var _couples = new List<Couples>();
                    var _listOfCouples = new List<List<Couples>>();
                    var _listOfListOfCouples = new List<List<List<Couples>>>();

                    MRaspisanie file = new MRaspisanie();
                    // string fileName = "DATA";//Сделать id файла
                    bool isFCFull = false;
                    bool isGroupsFull = false;
                    bool isCourceFind = false;





                    string infoConcatWithWeek = indexOfWeek[0] + indexOfWeek[iow];

                    string[] rows = infoConcatWithWeek.Split("<row>");
                    for (int j = 0; j < rows.Length; j++)
                    {

                        string[] cells = rows[j].Split("<cell>");
                        for (int z = 0; z < cells.Length; z++)
                        {
                            //заполнение первичных элементов модели (не массивов)
                            if (isFCFull == false/* && iow == 0*/)
                            {
                                //Все возможные обозначения для поиска первичных элементов модели
                                string[] firstComponents = new string[] { "Факультет", "Форма обучения", "курс", "неделя" };

                                for (int jj = 0; jj < firstComponents.Length; jj++)
                                {
                                    //Содержит ли клетка в себе один из элементов модели
                                    if (cells[z].Contains(firstComponents[jj], System.StringComparison.CurrentCultureIgnoreCase))
                                    {
                                        //какой элемент модели она содержит
                                        switch (firstComponents[jj])
                                        {
                                            case "Факультет": file.faculty = cells[z]; break;//Тут должны быть ещё проверки для имени

                                            case "Форма обучения": file.formOfEdu = cells[z]; break;

                                            case "курс": if (isCourceFind == false) { file.cource = cells[z]; isCourceFind = true; } break;

                                            case "неделя": file.weekId = cells[z]; break;

                                            default: Console.WriteLine("NULL"); break;
                                        }
                                        break;
                                    }

                                    if (!String.IsNullOrEmpty(file.faculty) && !String.IsNullOrEmpty(file.formOfEdu) && !String.IsNullOrEmpty(file.cource) && !String.IsNullOrEmpty(file.weekId))
                                    {
                                        isFCFull = true;
                                    }
                                }

                            }
                            else
                            {

                                if (!(isGroupsFull == true) && !String.Compare(cells[z], "").Equals(0) && !String.Compare(cells[z], "</cell>").Equals(0) && !String.Compare(cells[z], "</cell></row>").Equals(0))
                                {

                                    string[] groupNames = new string[cells.Length - z + 1];
                                    //file.group = new Group[cells.Length - z + 1];
                                    Group Lgroup = new Group();

                                    for (int curRow = 0; curRow < cells.Length - z; curRow++)
                                    {
                                        groupNames[curRow] = cells[z + curRow];
                                        Group _groupInList = new Group()
                                        {
                                            groupName = groupNames[curRow]
                                        };
                                        _groups.Add(_groupInList);



                                        Console.WriteLine($"///////////////////////{groupNames[curRow]}");

                                        string[] daysOfTheWeek = new string[] { "понедельник", "вторник", "среда", "четверг", "пятница" };

                                        int workDaysInCurWeek = 0;

                                        for(int dayCount = 0; dayCount < daysOfTheWeek.Length; dayCount++)
                                        {
                                            if (indexOfWeek[iow].Contains(daysOfTheWeek[dayCount]))
                                            {
                                                workDaysInCurWeek += 1;
                                            }
                                        }

                                        //Заполнение групп
                                        bool is1DayFound = false;
                                        // Console.WriteLine($"}}}}}}}}}}}}}}}}}}}}}} ЭТО {j+1} СТРОКА ИЗ {rows.Length}");
                                        for (int remRows = 1; remRows < rows.Length - j; remRows++)
                                        {

                                            string[] cellsInRemRows = rows[j + remRows].Split("<cell>");

                                            //Поиск 1 упоминания понедельнака
                                            if (is1DayFound == false)
                                            {
                                                for (int cellInCurRightRow = 0; cellInCurRightRow < cellsInRemRows.Length; cellInCurRightRow++)
                                                {                                      

                                                    for (int dotw = 0; dotw < daysOfTheWeek.Length; dotw++)
                                                    {

                                                        if (cellsInRemRows[cellInCurRightRow].Contains(daysOfTheWeek[dotw], System.StringComparison.CurrentCultureIgnoreCase))
                                                        {
                                                            Console.WriteLine($"|||||||||||||||| OOO {cellsInRemRows[cellInCurRightRow]}");

                                                            DayOfWeek fileDay = new DayOfWeek()
                                                            {
                                                                dayName = cellsInRemRows[cellInCurRightRow],
                                                                date = cellsInRemRows[cellInCurRightRow + 1]

                                                            };
                                                            _weekdays.Add(fileDay);
                                                            if (_weekdays.Count == daysOfTheWeek.Length || _weekdays.Count == workDaysInCurWeek)//скорее всего пробелма тут
                                                            {
                                                                _listOfWeekDays.Add(_weekdays);
                                                                _weekdays = new List<DayOfWeek>();
                                                            }

                                                            int curDayRows = 0;

                                                            for (int howMushRowsToNextDay = 1; howMushRowsToNextDay < rows.Length - j - remRows; howMushRowsToNextDay++)
                                                            {
                                                                string[] mesh = rows[j + remRows + howMushRowsToNextDay].Split("<cell>");

                                                                for (int dotw2 = 0; dotw2 < daysOfTheWeek.Length; dotw2++)
                                                                {
                                                                    if (!daysOfTheWeek[dotw].Equals("пятница") && mesh[cellInCurRightRow].Contains(daysOfTheWeek[dotw2], System.StringComparison.CurrentCultureIgnoreCase))
                                                                    {
                                                                        curDayRows = howMushRowsToNextDay;

                                                                        break;
                                                                    }
                                                                    else if (daysOfTheWeek[dotw].Equals("пятница") || howMushRowsToNextDay == rows.Length - j - remRows - 1)  //переделать под все дни
                                                                    {
                                                                        curDayRows = rows.Length - j - remRows;

                                                                        break;
                                                                    }
                                                                }//Console.WriteLine(mesh[cellInCurRightRow]); 
                                                                if (curDayRows != 0) break;
                                                            }

                                                            for (int para = 0; para < curDayRows; para++)
                                                            {
                                                                string[] mesh = rows[j + remRows + para].Split("<cell>");
                                                                //int bgr = 0;

                                                                /*for(int biggestRow = 0; biggestRow < curDayRows; biggestRow++)
                                                                {
                                                                    string[] probBiggest = rows[j + remRows + biggestRow].Split("<cell>");//мб не очень
                                                                    if (probBiggest.Length > rows[j + remRows].Split("<cell>").Length)
                                                                    {
                                                                        bgr = biggestRow;
                                                                    }
                                                                }*/

                                                                string[] meshPlusOne = rows[j + remRows].Split("<cell>");

                                                                if (mesh.Length < meshPlusOne.Length)
                                                                {
                                                                    // meshPlusOne = new string[rows[j + remRows + para + 1].Split("<cell>").Length];
                                                                    bool isFour = false;
                                                                    for (int _cells = 0; _cells < meshPlusOne.Length - 1; _cells++)
                                                                    {

                                                                        if (isFour != true && _cells < 4)
                                                                        {

                                                                            meshPlusOne[_cells] = mesh[_cells];

                                                                        }
                                                                        else if (_cells == 4)
                                                                        {

                                                                            meshPlusOne[_cells] = "";//в самый первый раз стирается значение, надо двигать

                                                                            isFour = true;
                                                                        }
                                                                        else
                                                                        {
                                                                            meshPlusOne[_cells] = mesh[meshPlusOne.Length - _cells];
                                                                        }

                                                                    }
                                                                    if (4 + curRow >= meshPlusOne.Length)
                                                                    {
                                                                        Console.WriteLine("{0} {1}  --- MPO - b", meshPlusOne[3], meshPlusOne[4 + curRow - ((4 + curRow - mesh.Length + 1))]);
                                                                        if ((para + 1) % 2 != 0)
                                                                        {
                                                                            //file.group[curRow].week[dotw].couples[coupleId] = new Couples();

                                                                            Couples lCouples = new Couples()
                                                                            {
                                                                                time = meshPlusOne[3],
                                                                                discipline = meshPlusOne[4 + curRow - ((4 + curRow - mesh.Length + 1))]
                                                                            };

                                                                            _couples.Add(lCouples);
                                                                        }
                                                                        else
                                                                        {
                                                                            _couples[para / 2].otherInfo = meshPlusOne[4 + curRow - ((4 + curRow - mesh.Length + 1))];

                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.WriteLine("{0} {1}  --- MPO -g", meshPlusOne[3], meshPlusOne[4 + curRow]);
                                                                        if ((para + 1) % 2 != 0)
                                                                        {
                                                                            //file.group[curRow].week[dotw].couples[coupleId] = new Couples();

                                                                            Couples lCouples = new Couples()
                                                                            {
                                                                                time = meshPlusOne[3],
                                                                                discipline = meshPlusOne[4 + curRow]
                                                                            };

                                                                            _couples.Add(lCouples);
                                                                        }
                                                                        else
                                                                        {
                                                                            _couples[para / 2].otherInfo = meshPlusOne[4 + curRow];

                                                                        }

                                                                    }

                                                                }
                                                                else
                                                                {
                                                                    if (4 + curRow >= mesh.Length)
                                                                    {

                                                                        Console.WriteLine("{0} {1} - b", mesh[3], mesh[4 + curRow - (4 + curRow - mesh.Length + 1)]);
                                                                        if ((para + 1) % 2 != 0)
                                                                        {
                                                                            //file.group[curRow].week[dotw].couples[coupleId] = new Couples();

                                                                            Couples lCouples = new Couples()
                                                                            {
                                                                                time = mesh[3],
                                                                                discipline = mesh[4 + curRow - ((4 + curRow - mesh.Length + 1))]
                                                                            };

                                                                            _couples.Add(lCouples);
                                                                        }
                                                                        else
                                                                        {
                                                                            _couples[para / 2].otherInfo = mesh[4 + curRow - ((4 + curRow - mesh.Length + 1))];

                                                                        }

                                                                    }
                                                                    else
                                                                    {
                                                                        Console.WriteLine("{0} {1} -g", mesh[3], mesh[4 + curRow]);
                                                                        if ((para + 1) % 2 != 0)
                                                                        {
                                                                            //file.group[curRow].week[dotw].couples[coupleId] = new Couples();

                                                                            Couples lCouples = new Couples()
                                                                            {
                                                                                time = mesh[3],
                                                                                discipline = mesh[4 + curRow]
                                                                            };

                                                                            _couples.Add(lCouples);
                                                                        }
                                                                        else
                                                                        {
                                                                            _couples[para / 2].otherInfo = mesh[4 + curRow];

                                                                        }

                                                                    }


                                                                }



                                                            }


                                                            if (_couples.Count == curDayRows / 2)
                                                            {
                                                                _listOfCouples.Add(_couples);
                                                                _couples = new List<Couples>();
                                                            }

                                                            Console.WriteLine($"llllllllllllllllllllllllДоступно строк {curDayRows}");
                                                            //запись дня недели
                                                            //is1DayFound = true;

                                                        }



                                                    }


                                                    if (cellsInRemRows[cellInCurRightRow].Contains("пятница", System.StringComparison.CurrentCultureIgnoreCase))
                                                    {
                                                        _listOfListOfCouples.Add(_listOfCouples);
                                                        _listOfCouples = new List<List<Couples>>();
                                                    }
                                                }
                                            }

                                            if (is1DayFound == true)
                                            {



                                            }
                                            else Console.WriteLine("||||");



                                        }


                                    }




                                    isGroupsFull = true;

                                }


                            }






                            Console.WriteLine(cells[z]);

                        }
                    }
               /* if(iow == 0)
                    {
                        continue;
                    }*/

                _mrasp.Add(file);


                Console.WriteLine($"///////////////////////////////////////////\n{file.faculty}{file.formOfEdu}{file.cource}{file.weekId}");


                //for (int jopa = 0; jopa < file.group.Length - 1; jopa++) Console.WriteLine(file.group[jopa].groupName);
                Console.WriteLine(_mrasp.Count);
                    //Тут сериализация

                    for (int Jfiles = 0; Jfiles < _mrasp.Count; Jfiles++)
                    {
                        MRaspisanie json = new MRaspisanie()
                        {
                            faculty = _mrasp[Jfiles].faculty.Remove(_mrasp[Jfiles].faculty.IndexOf("<")),
                            formOfEdu = _mrasp[Jfiles].formOfEdu.Remove(_mrasp[Jfiles].formOfEdu.IndexOf("<")),
                            cource = _mrasp[Jfiles].cource/*.Remove(_mrasp[Jfiles].cource.IndexOf(""))*/,
                            weekId = _mrasp[Jfiles].weekId.Remove(_mrasp[Jfiles].weekId.IndexOf("<")),
                            group = _mrasp[Jfiles].group
                        };
                        json.group = new Group[_groups.Count];

                        for (int Jgroups = 0; Jgroups < _groups.Count; Jgroups++)
                        {
                            json.group[Jgroups] = new Group()
                            {
                                groupName = _groups[Jgroups].groupName.Remove(_groups[Jgroups].groupName.IndexOf("<"))
                            };

                            var _curDays = new List<DayOfWeek>();

                            if (_listOfWeekDays.Count != 0)
                            {
                                _curDays = _listOfWeekDays[Jgroups];
                            }
                            else
                            {
                                _curDays = _weekdays;
                            }

                            json.group[Jgroups].week = new DayOfWeek[_curDays.Count];

                            for (int Jweeks = 0; Jweeks < _curDays.Count; Jweeks++)
                            {
                                json.group[Jgroups].week[Jweeks] = new DayOfWeek
                                {
                                    dayName = _curDays[Jweeks].dayName.Remove(_curDays[Jweeks].dayName.IndexOf("<")),
                                    date = OADateToDate.ToDate(_curDays[Jweeks].date.Remove(_curDays[Jweeks].date.IndexOf("<")))
                                };

                                var index1 = new List<List<Couples>>();
                                if (_listOfListOfCouples.Count == 0)
                                {
                                    index1 = _listOfCouples;
                                }
                                else
                                {
                                    index1 = _listOfListOfCouples[Jgroups];
                                }
                                var index2 = index1[Jweeks];


                                json.group[Jgroups].week[Jweeks].couples = new Couples[index1[Jweeks].Count];

                                for (int Jcouples = 0; Jcouples < index1[Jweeks].Count; Jcouples++)
                                {
                                    json.group[Jgroups].week[Jweeks].couples[Jcouples] = new Couples
                                    {
                                        time = index2[Jcouples].time.Remove(index2[Jcouples].time.IndexOf("<"))
                                    };

                                    if (index2[Jcouples].discipline.Contains("<"))
                                    {
                                        json.group[Jgroups].week[Jweeks].couples[Jcouples].discipline = index2[Jcouples].discipline.Remove(index2[Jcouples].discipline.IndexOf("<"));
                                    }
                                    else
                                    {
                                        json.group[Jgroups].week[Jweeks].couples[Jcouples].discipline = index2[Jcouples].discipline;
                                    }

                                    if (index2[Jcouples].otherInfo.Contains("<"))
                                    {
                                        json.group[Jgroups].week[Jweeks].couples[Jcouples].otherInfo = index2[Jcouples].otherInfo.Remove(index2[Jcouples].otherInfo.IndexOf("<"));
                                    }
                                    else
                                    {
                                        json.group[Jgroups].week[Jweeks].couples[Jcouples].otherInfo = index2[Jcouples].otherInfo;
                                    }

                                }

                            }




                        }

                        int facultyIndex = 0;
                        int formOfEduIndex = 0;
                        int courceIndex = 0;
                        int weekIndex = 0;

                        for (int f = 0; f < Config.faculties.Length; f++)
                        {
                            if (json.faculty.Contains(Config.faculties[f]))
                                facultyIndex = f + 1;
                        }

                        for (int f = 0; f < Config.formOfEdu.Length; f++)
                        {
                            if (json.formOfEdu.Contains(Config.formOfEdu[f]))
                                formOfEduIndex = f + 1;
                        }

                        for (int c = 0; c < Config.cource.Length; c++)
                        {
                            if (json.cource.Contains(Config.cource[c]))
                                courceIndex = c + 1;
                        }

                        weekIndex = Convert.ToInt32(json.weekId.Remove(json.weekId.IndexOf(" ")));



                        JsonConvert.SerializeObject(json);
                        File.Create($"{pathToEndFiles}\\Data{facultyIndex}{formOfEduIndex}{courceIndex}{weekIndex}.json").Close();
                        File.WriteAllText($"{pathToEndFiles}\\Data{facultyIndex}{formOfEduIndex}{courceIndex}{weekIndex}.json", JsonConvert.SerializeObject(json));
                        //findex += 1;
                    }
                }





            }

        }






    }
}