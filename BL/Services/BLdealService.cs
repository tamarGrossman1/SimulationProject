using BL.Api;
using BL.Models;
using DAL.Appi;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace BL.Services
{
    public class BLdealService : Ibldeal 
    {
        Idal dal;

        public BLdealService(Idal dal)
        {
            this.dal = dal;
        }
        public BLdeal ConvertToBl(Deal d)
        {
            return new () { DealId = d.DealId, DealDescription = d.DealDescription };
          
        }
        public Deal convertToDal(BLdeal d)
        {
            return new Deal()
            { DealId = d.DealId, DealDescription = d.DealDescription };
         }
        public async Task<List<BLdeal>> GetAllDeals()
        {
            List<BLdeal> lst = new();
            dal.deal.Read().Result.ForEach(d => lst.Add(ConvertToBl(d)));
            return  lst;
        }
        public bool Update(BLdeal item)
        {
            if (item == null) throw new ArgumentNullException("item");
            dal.deal.Update(convertToDal(item));
            return true;
        }
        public bool Create(BLdeal item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            else
            {
                dal.deal.Create(convertToDal(item));
                return true;
            }
            
         }
     }

 }

