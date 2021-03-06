﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphLib;
using System.Drawing;

namespace GenericGraph
{
    public class CitiesMap //карта с городами и  дорогами
    {
        private Graph<City, Road> mainGraph = new Graph<City, Road>(); //граф городов

        public Graph<City, Road> MainGraph
        {
            get
            {
                return mainGraph;
            }
        }

        public City Selected { get; set; } //выбранный текущий город (для построения дороги)

        public void AddCity(string name, float x, float y) //добавить город
        {
            City city = new GenericGraph.City(name);
            city.Pos = new PointF(x, y);
            MainGraph.AddVertex(city);
        }

        public void AddRoad(int length, City c1, City c2) //добавить дорогу
        {
            Road road = new GenericGraph.Road(length);
            road.Connections[0] = c1;
            road.Connections[1] = c2;
            MainGraph.AddEdge(road, c1, c2);
        }

        public void RemoveCity(City city) //удалить город
        {
            mainGraph.RemoveVertex(city);
        }

        public City FindByPos(float x, float y) //найти город по координатам
        {
            foreach (City city in MainGraph)
            {
                if (x >= city.Pos.X - city.Size.Width / 2 && x <= city.Pos.X + city.Size.Width / 2 &&
                    y >= city.Pos.Y - city.Size.Height / 2 && y <= city.Pos.Y + city.Size.Height / 2)
                {
                    return city;
                }
            }
            return null;
        }
    }
}
