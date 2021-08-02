using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using Local_Produce_Initial_Verson.Models;
using System.Net;

namespace Local_Produce_Initial_Verson.DAO
{
    public class FarmersMarketSqlDao: IFarmersMarketDao
    {
        private readonly string connectionString;

        public List<FarmersMarket> loadingList = new List<FarmersMarket>();

        public FarmersMarket tempMarket = new FarmersMarket();

        //add constructor for connection string later

        public void PopulateFarmersMarket()
        {
            //Call the CSV file - discard response
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://search.ams.usda.gov/farmersmarkets/ExcelExport.aspx");
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            try
            {
                
                string path = @"C:\Users\Student\Downloads\Export.csv";
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string eachLine = sr.ReadLine();
                        string[] item = eachLine.Split(",");
                                                   
                        if(!item.Contains("FMID"))
                        {
                            tempMarket.FMID = Int32.Parse(item[0]);
                            tempMarket.MarketName = item[1];
                            tempMarket.Website = item[2];
                            tempMarket.Facebook = item[3];
                            tempMarket.Twitter = item[4];
                            tempMarket.Youtube = item[5];
                            tempMarket.OtherMedia = item[6];
                            tempMarket.Street = item[7];
                            tempMarket.City = item[8];
                            tempMarket.County = item[9];
                            tempMarket.State = item[10];
                            tempMarket.Zip = item[11];
                            tempMarket.Season1Date = item[12];
                            tempMarket.Season1Time = item[13];
                            tempMarket.Season2Date = item[14];
                            tempMarket.Season2Time = item[15];
                            tempMarket.Season3Date = item[16];
                            tempMarket.Season3Time = item[17];
                            tempMarket.Season4Date = item[18];
                            tempMarket.Season4Time = item[19];
                            tempMarket.X = item[20];
                            tempMarket.Y = item[21];
                            tempMarket.Location = item[22];
                            tempMarket.Credit = item[23];
                            tempMarket.WIC = item[24];
                            tempMarket.WICcash = item[25];
                            tempMarket.SFMNP = item[26];
                            tempMarket.SNAP = item[27];
                            tempMarket.Organic = item[28];
                            tempMarket.Bakedgoods = item[29];
                            tempMarket.Cheese = item[30];
                            tempMarket.Crafts = item[31];
                            tempMarket.Flowers = item[32];
                            tempMarket.Eggs = item[33];
                            tempMarket.Seafood = item[34];
                            tempMarket.Herbs = item[35];
                            tempMarket.Vegetables = item[36];
                            tempMarket.Honey = item[37];
                            tempMarket.Jams = item[38];
                            tempMarket.Maple = item[39];
                            tempMarket.Meat = item[40];
                            tempMarket.Nursery = item[41];
                            tempMarket.Nuts = item[42];
                            tempMarket.Plants = item[43];
                            tempMarket.Poultry = item[44];
                            tempMarket.Prepared = item[45];
                            tempMarket.Soap = item[46];
                            tempMarket.Trees = item[47];
                            tempMarket.Wine = item[48];
                            tempMarket.Coffee = item[49];
                            tempMarket.Beans = item[50];
                            tempMarket.Fruits = item[51];
                            tempMarket.Grains = item[52];
                            tempMarket.Juices = item[53];
                            tempMarket.Mushrooms = item[54];
                            tempMarket.PetFood = item[55];
                            tempMarket.Tofu = item[56];
                            tempMarket.WildHarvested = item[57];
                            tempMarket.updateTime = item[58];


                            loadingList.Add(tempMarket);

                        }  
                               
  
                                              
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured while writing to the Farmers Market Database: { ex.Message}");
            }

            //Delete the csv file

            try
            {
                string path = @"C:\Users\Student\Downloads\Export.csv";               

                if (File.Exists(path))
                {
                    // If file found, delete it    
                    File.Delete(path);
                    Console.WriteLine("File deleted.");
                }
                else Console.WriteLine("File not found");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured while attempting to delete Export.CSV: { ex.Message}");
            }
        }

        //add methods to read and write to database here

    }
}
