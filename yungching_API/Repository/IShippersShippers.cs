using yungching_API.Model;
namespace yungching_API.Repository
{
    public interface IShippersShippers
    {
        public IEnumerable<Shippers> GetShippersList();

        public Shippers GetShippers(int ShipperID);

        public int DelShippers(int ShipperID);
    }
}
