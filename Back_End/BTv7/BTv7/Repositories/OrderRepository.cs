﻿using BTv7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTv7.Repositories
{
    public class OrderRepository : Repository<Order>
    {
        public List<Order> GetAllOrderByCustomerID(int cid)
        {
            return this.GetAll().Where(x => x.CustomerID == cid).ToList();
        }

        public List<Order> GetOrderByCustomerNOrderID(int cid, int oid)
        {
            return this.GetAll().Where(x => x.CustomerID == cid && x.ID == oid).ToList();
        }

        public List<Order> GetOrderByCustomerNStatusID(int cid, int osid)
        {
            return this.GetAll().Where(x => x.CustomerID == cid && x.OrderStatusID == osid).ToList();
        }

        public List<Order> GetOrderByCustomerNSaleTypeID(int cid, int stid)
        {
            return this.GetAll().Where(x => x.CustomerID == cid && x.SaleTypeID == stid).ToList();
        }

        public List<Order> GetOrderByDeliverymanID(int id)
        {
            return this.context.Set<Order>().Where(x => x.SellBy == id && x.OrderStatusID == 2).OrderBy(y=> y.ID).ToList();
        }

        public Order GetOrderByDeliverymanIDNOrderIDnStatusID(int eid, int oid)
        {
            List<Order> orderFromDB = this.GetAll();
            return orderFromDB.FirstOrDefault(x => x.SellBy == eid && x.ID == oid && x.OrderStatusID == 2);
        }

    }
}