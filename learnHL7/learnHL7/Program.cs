﻿using System;

namespace learnHL7
{
    class Program
    {
        static void Main(string[] args)
        {

            var message = new HL7Message()
            {
                Segments = new List<Segment>()
                {
                   new Segment()
                   {
                      Name = "PID",
                      Fields = new List<Field>()
                         {
                            new Field()
                            {
                               Name = "SomeField",
                               Fields = new List<Field>()
                                  {
                                     new Field()
                                     {
                                        Name = "SomeSubField",
                                        Fields = new List<Field>()
                                           {
                                              new Field()
                                              {
                                                 Name = "SomeSubSubField",
                                              }
                                           }
                                     }
                                  }
                            }
                         }
                   }
                }
            };
        }
    }
}
