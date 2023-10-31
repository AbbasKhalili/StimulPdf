namespace StimulPdf.Services
{
    public class SheetFacadeReporting : ReportingBase, ISheetFacadeReporting
    {
        public SheetFacadeReporting() : base("Sheet.mrt")
        {
        }

        public async Task<ReportDto> PrintSheet()
        {
            // get data from db
            var sheet = new SheetDto
            {
                CompanyName = "CompanyName",
                BranchName = "BranchName",
                IndicatorNo = "IndicatorNo",
                BranchId = 1,
                OrderId = 1,
                RegistrationPlate = "100",
                Master = "Mr.X",
                MobileMaster = "mobile",
                Supervision = "Supervision",
                Contractor= "Contractor",
                ProjectAddress = "P.Address",
                ProjectTitle = "p.title",
                ExampleNumber = 1005,
                PrefixExampleNumber = "C",
                ExampleDate = "2020-12-12",
                CementType = 2,
                EnvironmentTemperature = 25,
                ConcreteTemperature = 20,
                Cutie = 15,
                Slump = 8,
                Volume = 30,
                Axis = "A1-C3",
                ConcreteSeller = "C.Seller",
                Fc = 300,
                NeedExampleCount = 0,
                ExamplePlaceTitle = "Wall",
                ExamplePlaceDesc = "Wall.2.3",
                Description = "nothing",
                Breaks = new List<SheetBreakDto>
                {
                    new SheetBreakDto{Id=1,OrderId=1,BreakDate="2020-12-19",Age=7,Length=15,Width=15,Height=15,Weight=7890,Power=37900},
                    new SheetBreakDto{Id=2,OrderId=1,BreakDate="2020-12-19",Age=7,Length=15,Width=15,Height=15,Weight=7950,Power=38800},
                    new SheetBreakDto{Id=3,OrderId=1,BreakDate="2020-12-29",Age=17,Length=15,Width=15,Height=15,Weight=7911,Power=63100},
                    new SheetBreakDto{Id=4,OrderId=1,BreakDate="2020-12-29",Age=17,Length=15,Width=15,Height=15,Weight=8054,Power=65450},
                },
                Averages = new List<AgeAverageDto>
                {
                    new AgeAverageDto{Age=7,PushingResistance=25},
                    new AgeAverageDto{Age=17,PushingResistance=35},
                }
            };
            GenerateReport("sheet", sheet);

            return GeneratePdf($"[{sheet.CompanyName}]");
        }
    }
}
