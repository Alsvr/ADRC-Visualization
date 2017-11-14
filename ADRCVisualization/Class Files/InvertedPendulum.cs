﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADRCVisualization.Class_Files
{
    class InvertedPendulum
    {
        private DateTime date;
        private double velocity = 0;
        private double theta;
        private double radius;
        private double gravity = 9.81;

        public InvertedPendulum(double theta, double radius)
        {
            date = DateTime.Now;
            this.theta = theta * Math.PI / 180;
            this.radius = radius;
        }

        public double Step(double force)//horizontal force
        {
            double arcDistance;
            double dT;
            double alpha;

            dT = DateTime.Now.Subtract(date).TotalSeconds;
            if (dT != 0)
            {
                arcDistance = velocity * dT;

                //Console.WriteLine(Math.Asin(Math.Abs(arcDistance) / radius));
                
                alpha = Math.Asin(arcDistance / radius);

                velocity = velocity + gravity * Math.Sin(theta) * dT + force * dT;

                date = DateTime.Now;

                velocity *= 0.9985;//resistance

                theta -= alpha;

                //Console.WriteLine(force + " " + velocity + " " + arcDistance);
                //Console.WriteLine(theta + " " + radius + " " + dT + " " + arcDistance + " " + alpha + " " + velocity);
            }


            return theta;
        }
    }
}