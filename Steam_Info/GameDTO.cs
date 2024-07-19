namespace Steam_Info
{
    /// <summary>
    /// DTO-класс, содержащий данные по игре
    /// </summary>
    public class GameDTO
    { 
        public string? Name { get; set; }
        public string? Score {get; set; }
        public string? DiscountPct { get; set; } 
        public string? OriginalPrice { get; set; } 
        public string? FinalPrice { get; set; }
    }
}