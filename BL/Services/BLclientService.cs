using BL.Api;
using BL.Models;
using DAL;
using DAL.Appi;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace BL.Services
{
    public class BLclientService :IblClient
    {

        Idal dal;

        public BLclientService(Idal dal)
        {
            this.dal = dal;
        }
        public Customer convertToDal(BLclient b) {
            return new Customer() { CustomersId = b.CustomersId, Phone = b.Phone, CompNameCustName = b.CompNameCustName, Mail = b.Mail, ConnectPerson = b.ConnectPerson, CustomerType = b.CustomerType };
        }
        
        public BLclient ConvertToBl(Customer c)
        {
            return new() { CustomersId = c.CustomersId, Phone = c.Phone, CompNameCustName = c.CompNameCustName, Mail = c.Mail, ConnectPerson = c.ConnectPerson, CustomerType = c.CustomerType };
        }

        public async Task<BLclient> GetClientById(string Mail)
        {
            var list = await dal.client.Read();
            var client = list.Find(c => c.Mail == Mail);

            if (client == null)
                return null;

            return ConvertToBl(client);
        }

        public async Task<List<BLclient>> GetAll()
        {
            List<BLclient> lst = new List<BLclient>();
            dal.client.Read().Result.ForEach(c => lst.Add(ConvertToBl(c)));
            return lst;
        }

        public bool Search(BLclient item)
        {
            foreach (BLclient client in GetAll().Result)
            {
                if (client.CustomersId == item.CustomersId) return true;

                else return false;
            }
            return false;

        }

        //public bool Create(BLclient item)
        //{
        //    if (item == null)
        //        throw new ArgumentNullException(nameof(item));

        //    if (GetClientById(item.Mail) == null)
        //    {
        //        dal.client.Create(convertToDal(item));
        //        return true;
        //    }

        //    return false;
        //}
        public async Task<bool> Create(BLclient item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            var existingClient = await GetClientById(item.Mail);

            if (existingClient == null)
            {
                dal.client.Create(convertToDal(item));
                return true;
            }

            return false;
        }

        public bool Update(BLclient item)
        {
            if (item == null) throw new ArgumentNullException("item");
            dal.client.Update(convertToDal(item));
            return true;
        }
    }
}
