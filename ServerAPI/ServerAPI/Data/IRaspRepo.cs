using System.Collections.Generic;

namespace ServerAPI.Data
{
    public interface IRaspRepo
    {
        IEnumerable<MRaspisanie> GetAllRasp();

        MRaspisanie GetRaspById(int id);
    }
}