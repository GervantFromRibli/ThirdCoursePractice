﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Models;

namespace TicketManagement.BLL
{
    public interface IAreaBLL
    {
        public Task<Area> GetArea(int id);

        public Task DeleteArea(int id);

        public List<Area> GetAreas();

        public Task CreateArea(int layoutId, string description, int startCoordX, int startCoordY, int endCoordX, int endCoordY);

        public Task UpdateArea(int id, int layoutId, string description, int startCoordX, int startCoordY, int endCoordX, int endCoordY);
    }
}