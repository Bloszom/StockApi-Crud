using morningclassonapi.DTO.Account;
using morningclassonapi.Model;

namespace morningclassonapi.Mapper
{
    public static class StockMapper
    {

        public static Stock ToStockFromCreateDTO(this CreateStockDTO stockDto)
        {

            return new Stock
            {
                Symbol = stockDto.Symbol,
                CompanyName = stockDto.CompanyName,
                Purchase = stockDto.Purchase,
                Lastdiv = stockDto.Lastdiv,
                Industry = stockDto.Industry,
                MarketCap = stockDto.MarketCap
            };

        }

        public static Stock ToStock(this Stock stockDto)
        {

            return new Stock
            {
                Id = stockDto.Id,
                Symbol = stockDto.Symbol,
                CompanyName = stockDto.CompanyName,
                Purchase = stockDto.Purchase,
                Lastdiv = stockDto.Lastdiv,
                Industry = stockDto.Industry,
                MarketCap = stockDto.MarketCap,
                Comments = stockDto.Comments.ToList()
            };

        }

    }
}
