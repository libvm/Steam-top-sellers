namespace Steam_Info
{
  class Program
  {
    const int gameToListCount = 10; // от 1 до 30, по ТЗ - 10
    static void Main()
    {
      var games = ScrapeService.ScrapeInfo(gameToListCount);
      foreach (var game in games)
      {
        if (game.DiscountPct == null && game.OriginalPrice == null)
        Console.WriteLine(Messages.without_discount, game.Score, game.Name, game.FinalPrice);
        else Console.WriteLine(Messages.with_discount, game.Score, game.Name, game.OriginalPrice, game.DiscountPct, game.FinalPrice);
      }
    }
  }
}