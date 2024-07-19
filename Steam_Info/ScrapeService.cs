using HtmlAgilityPack;
using Steam_Info.strings;

namespace Steam_Info
{
    /// <summary>
    /// Сервис для парсинга веб-страницы Steam-а
    /// </summary>
    public static class ScrapeService
    {
        private static readonly string url = Urls.main_page_ru;

        private static string? GetInfo(this HtmlNode? element, string selector) => HtmlEntity.DeEntitize(
                            element.QuerySelector(selector)?.InnerText);

        public static List<GameDTO> ScrapeInfo(int gameToListCount)
        {
            var web = new HtmlWeb();
            var document = web.Load(url);
            var games = new List<GameDTO>();
            
            // достаём нужные данные по css-селекторам
            var topSellers = document.DocumentNode.QuerySelector(cssSelector: Selectors.tab_content);
            var topSellersItems = topSellers.QuerySelector(Selectors.tab_content_items);
            var gameElements = topSellersItems.QuerySelectorAll(Selectors.tab_item);

            for (int i = 0; i < gameToListCount; i++)
            {
                var game = gameElements[i];

                // достаём данные по игре
                var name = game.GetInfo(Selectors.tab_item_name); 
                var discountPct = game.GetInfo(Selectors.discount_pct);
                var originalPrice = game.GetInfo(Selectors.discount_original_price);
                var finalPrice = game.GetInfo(Selectors.discount_final_price);

                games.Add(new GameDTO{Name = name, Score = (i + 1).ToString(), 
                                        DiscountPct = discountPct, OriginalPrice = originalPrice, 
                                        FinalPrice = finalPrice});
            }

            return games;
        }
    }
}