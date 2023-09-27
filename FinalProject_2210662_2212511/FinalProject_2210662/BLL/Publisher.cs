using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject_2210662.DAL;

namespace FinalProject_2210662.BLL
{
    public class Publisher
    {
        private int publisherId;
        private string publisherName;
        private string webAddress;

        public int PublisherId { get => publisherId; set => publisherId = value; }
        public string PublisherName { get => publisherName; set => publisherName = value; }
        public string WebAddress { get => webAddress; set => webAddress = value; }




        public bool Check_existed_id(int id)
        {
            return PublisherDB.Duplicated_ID_validation(id);
        }

        public List<Publisher> GetAllPublisher()
        {
            return PublisherDB.GetAllRecords();
        }

    }
}
