namespace ImportExcelFileWatch
{
    public class AppConfig
    {
        public int Interval { get; set; } = 60;
        public string watch_folder { get; set; }
        public string processed_folder { get; set; }
        public string rejected_folder { get; set; }
    }
}
