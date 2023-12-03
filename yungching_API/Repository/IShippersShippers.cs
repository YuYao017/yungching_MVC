using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using yungching_API.Model;
using System.Linq;
using yungching_API.Repository;
namespace yungching_API.Repository
{
    public interface IShippersShippers
    {
        public ActionResult<IEnumerable<Shipper>> GetShippersList();

        public Shipper GetShipper(int ShipperID);

        public int DelShipper(int ShipperID);

        public int updateShipper(int ShipperID, Shipper Shippers);

        public int InsShipper(Shipper Shippers);
    }
}
