using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

using yungching_MVC.Models;

using System.Linq;
 
namespace yungching_MVC.Services
{
    public interface IShippersShippers
    {
        public List<Shipper> GetShippersList();

        //public Shipper GetShipper(int ShipperID);

        //public int DelShipper(int ShipperID);

        //public int updateShipper(int ShipperID, Shipper Shippers);

        //public int InsShipper(Shipper Shippers);
    }
}
