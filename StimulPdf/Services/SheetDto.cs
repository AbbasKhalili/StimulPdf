using System;
using System.Collections.Generic;

namespace StimulPdf.Services
{
    public class SheetDto
    {
        public string CompanyName { get; set; }
        public string BranchName { get; set; }
        public string IndicatorNo { get; set; }
        public string CreateDate => DateTime.Now.ToString();
        public string CreateTime => DateTime.Now.ToLocalTime().ToString();

        public long BranchId { get; set; }
        public long OrderId { get; set; }

        public string RegistrationPlate { get; set; }
        public string Master { get; set; }
        public string MobileMaster { get; set; }
        public string Supervision { get; set; }
        public string Contractor { get; set; }
        public string ProjectAddress { get; set; }
        public string ProjectTitle { get; set; }
        public long ExampleNumber { get; set; }
        public string PrefixExampleNumber { get; set; }
        public string ExampleDate { get; set; }
        public int CementType { get; set; }
        public int EnvironmentTemperature { get; set; }
        public int ConcreteTemperature { get; set; }
        public int Cutie { get; set; }
        public float Slump { get; set; }
        public int Volume { get; set; }
        public string Axis { get; set; }
        public string ConcreteSeller { get; set; }
        public long Fc { get; set; }
        public long CharacteristicResistance => Fc / 10;
        public string Grade => $"C{CharacteristicResistance}";
        public int NeedExampleCount { get; set; }
        public string ExamplePlaceTitle { get; set; }
        public string ExamplePlaceDesc { get; set; }
        public string Description { get; set; }
        public List<string> Additives { get; set; }
        public List<SheetBreakDto> Breaks { get; set; }
        public List<AgeAverageDto> Averages { get; set; }
    }
    public class BreakDto
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public string BreakDate { get; set; }
        public int Age { get; set; }
        public float Length { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public int Weight { get; set; }
        public long Power { get; set; }
    }
    public class SheetBreakDto : BreakDto
    {
        public double LoadingLevel => Length > 0 ? Math.Round(Length * Width, 2) : 0;
        public double Volume => Math.Round(Length * Width * Height, 2);
        public double WeightSpec => Weight > 0 && LoadingLevel > 0 ? Math.Round(Weight / (LoadingLevel * Height), 1) : 0;
        public double Cube => Power > 0 ? Math.Round(Power / LoadingLevel, 0) : 0;
        public double Cylinder { get; set; }
        public double AveragePushingResistance { get; set; }
    }

    public class AgeAverageDto
    {
        public int Age { get; set; }
        public double PushingResistance { get; set; }
    }
}
