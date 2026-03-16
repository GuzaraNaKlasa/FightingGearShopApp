using FightGearShopApp.Core.Contracts;
using FightGearShopApp.Models.Statistic;

using Microsoft.AspNetCore.Mvc;

namespace FightGearShopApp.Controllers
{
    public class StatisticController : Controller
    {
        private readonly IStatisticService statisticsService;
       
        public StatisticController(IStatisticService statisticService)
        {
            this.statisticsService = statisticService;
        }

        public IActionResult Index()
        {
            StatisticVM statistics =new StatisticVM();

            statistics.CountClients = statisticsService.CountClients();
            statistics.CountProducts = statisticsService.CountProducts();
            statistics.CountOrders = statisticsService.CountOrders();
            statistics.SumOrders = statisticsService.SumOrders();

            return View(statistics);
        }
    }
}
