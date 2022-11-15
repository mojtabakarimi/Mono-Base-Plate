using System;
using System.Collections.Generic;
using Base_Plate_Engine.Common.Section.Shapes;
using Base_Plate_Engine.Design;
using netDxf;
using netDxf.Entities;
using netDxf.Header;
using netDxf.Tables;

namespace Mono_Base_Plate.AutoCAD
{
    public static class DxfWriter
    {
        public static void Create(BasePlateInput basePlateInput, DesignResult designResult, string FileName)
        {
            var dxfDocument = new DxfDocument(DxfVersion.AutoCad2013)
            {
                Name = "Mojtaba Karimi"
            };

            var centerPoint = new Vector3(0, 0, 0);

            //Draw Pedestal
            var polyline = new Polyline
            {
                Color = AciColor.Magenta
            };
            polyline.Vertexes.AddRange(CreateRectangle(centerPoint, basePlateInput.Np, basePlateInput.Bp));
            dxfDocument.AddEntity(polyline);

            //Draw Base Plate
            polyline = new Polyline
            {
                Color = AciColor.Red
            };
            polyline.Vertexes.AddRange(CreateRectangle(centerPoint, basePlateInput.N, basePlateInput.B));
            dxfDocument.AddEntity(polyline);

            //Draw Rebars
            var left = -basePlateInput.Np / 2 + basePlateInput.Cover;
            var top = -basePlateInput.Bp / 2 + basePlateInput.Cover;

            var xStep = (basePlateInput.Np - 2 * basePlateInput.Cover) / (basePlateInput.nrN - 1);
            var yStep = (basePlateInput.Bp - 2 * basePlateInput.Cover) / (basePlateInput.nrB - 1);

            Circle circle;
            for (var i = 0; i < basePlateInput.nrN; i++)
            {
                for (var j = 0; j < basePlateInput.nrB; j++)
                {
                    if (i == 0 || i == basePlateInput.nrN - 1)
                    {
                        var center = new Vector3(centerPoint.X + left + i * xStep, centerPoint.Y + top + j * yStep, centerPoint.Z);
                        circle = new Circle(center, basePlateInput.dr / 2) { Color = AciColor.Blue };

                        dxfDocument.AddEntity(circle);
                    }
                    else if (j == 0 || j == basePlateInput.nrB - 1)
                    {
                        var center = new Vector3(centerPoint.X + left + i * xStep, centerPoint.Y + top + j * yStep, centerPoint.Z);
                        circle = new Circle(center, basePlateInput.dr / 2) { Color = AciColor.Blue };

                        dxfDocument.AddEntity(circle);
                    }
                }
            }

            //Draw Anchor Bolts
            left = -basePlateInput.N / 2 + basePlateInput.a_N;
            top = -basePlateInput.B / 2 + basePlateInput.a_B;

            xStep = (basePlateInput.N - 2 * basePlateInput.a_N) / (basePlateInput.nbB - 1);
            yStep = (basePlateInput.B - 2 * basePlateInput.a_B) / (basePlateInput.nbN - 1);

            for (var i = 0; i < basePlateInput.nbB; i++)
            {
                for (var j = 0; j < basePlateInput.nbN; j++)
                {
                    if (i == 0 || i == basePlateInput.nbB - 1)
                    {
                        var center = new Vector3(centerPoint.X + left + i * xStep, centerPoint.Y + top + j * yStep, centerPoint.Z);

                        //Draw Bolt
                        circle = new Circle(center, basePlateInput.AnchorBolt.da / 2)
                        {
                            Color = AciColor.Red
                        };
                        dxfDocument.AddEntity(circle);

                        //Draw Cap Bolt
                        polyline = new Polyline
                        {
                            Color = AciColor.Cyan
                        };
                        polyline.Vertexes.AddRange(CreateHexagonal(center, basePlateInput.AnchorBolt.S));
                        dxfDocument.AddEntity(polyline);

                        //Draw Sleeve
                        circle = new Circle(center, basePlateInput.AnchorBolt.D / 2)
                        {
                            Color = AciColor.DarkGray
                        };
                        dxfDocument.AddEntity(circle);

                        //Draw Cap Plate
                        polyline = new Polyline
                        {
                            Color = AciColor.LightGray
                        };
                        polyline.Vertexes.AddRange(CreateRectangle(center, basePlateInput.AnchorBolt.W, basePlateInput.AnchorBolt.W));
                        dxfDocument.AddEntity(polyline);
                    }
                    else if (j == 0 || j == basePlateInput.nbN - 1)
                    {
                        var center = new Vector3(centerPoint.X + left + i * xStep, centerPoint.Y + top + j * yStep, centerPoint.Z);

                        //Draw Bolt
                        circle = new Circle(center, basePlateInput.AnchorBolt.da / 2)
                        {
                            Color = AciColor.Red
                        };
                        dxfDocument.AddEntity(circle);

                        //Draw Cap Bolt
                        polyline = new Polyline
                        {
                            Color = AciColor.Cyan
                        };
                        polyline.Vertexes.AddRange(CreateHexagonal(center, basePlateInput.AnchorBolt.S));
                        dxfDocument.AddEntity(polyline);

                        //Draw Sleeve
                        circle = new Circle(center, basePlateInput.AnchorBolt.D / 2)
                        {
                            Color = AciColor.DarkGray
                        };
                        dxfDocument.AddEntity(circle);

                        //Draw Cap Plate
                        polyline = new Polyline
                        {
                            Color = AciColor.LightGray
                        };
                        polyline.Vertexes.AddRange(CreateRectangle(center, basePlateInput.AnchorBolt.W, basePlateInput.AnchorBolt.W));
                        dxfDocument.AddEntity(polyline);
                    }
                }
            }

            polyline = new Polyline
            {
                Color = AciColor.Yellow
            };

            polyline.Vertexes.AddRange(CreateSection(centerPoint, basePlateInput.Sec));
            dxfDocument.AddEntity(polyline);

            var dimensionStyle = new DimensionStyle("Stand")
            {
                DimScaleOverall = 1,
                DimScaleLinear = 10,
                TextHeight = 3.6,
                ArrowSize = 3.6,
                LengthPrecision = 0,
                DimLineColor = AciColor.Green,
                TextColor = AciColor.Green,
                ExtLineColor = AciColor.Green,
                TextOffset = 0,
                ExtLine1Off = false,
                ExtLine2Off = false,
                ExtLineOffset = 1
            };

            const double offset = 10.0;
            const double lineOffset = 5.0;

            //Draw (Horizontal) Pedestal Dimension
            var linearDimension = new LinearDimension
            {
                Style = dimensionStyle,
                Offset = lineOffset,
                Rotation = 0,
                FirstReferencePoint = new Vector2(centerPoint.X - basePlateInput.Np / 2, centerPoint.Y + basePlateInput.Bp / 2 + offset),
                SecondReferencePoint = new Vector2(centerPoint.X + basePlateInput.Np / 2, centerPoint.Y + basePlateInput.Bp / 2 + offset)
            };
            dxfDocument.AddEntity(linearDimension);

            //Draw (Vertical) Pedestal Dimension
            linearDimension = new LinearDimension
            {
                Style = dimensionStyle,
                Offset = lineOffset,
                Rotation = 90,
                FirstReferencePoint = new Vector2(centerPoint.X - basePlateInput.Np / 2 - offset, centerPoint.Y - basePlateInput.Bp / 2),
                SecondReferencePoint = new Vector2(centerPoint.X - basePlateInput.Np / 2 - offset, centerPoint.Y + basePlateInput.Bp / 2)
            };
            dxfDocument.AddEntity(linearDimension);

            //Draw (Horizontal) Base Plate Dimension
            linearDimension = new LinearDimension
            {
                Style = dimensionStyle,
                Offset = lineOffset,
                Rotation = 0,
                FirstReferencePoint = new Vector2(centerPoint.X - basePlateInput.N / 2, centerPoint.Y + basePlateInput.Bp / 2 + offset / 2),
                SecondReferencePoint = new Vector2(centerPoint.X + basePlateInput.N / 2, centerPoint.Y + basePlateInput.Bp / 2 + offset / 2)
            };
            dxfDocument.AddEntity(linearDimension);

            //Draw (Horizontal) Base Plate Dimension
            linearDimension = new LinearDimension
            {
                Style = dimensionStyle,
                Offset = lineOffset,
                Rotation = 90,
                FirstReferencePoint = new Vector2(centerPoint.X - basePlateInput.Np / 2 - offset / 2, centerPoint.Y - basePlateInput.B / 2),
                SecondReferencePoint = new Vector2(centerPoint.X - basePlateInput.Np / 2 - offset / 2, centerPoint.Y + basePlateInput.B / 2)
            };
            dxfDocument.AddEntity(linearDimension);

            TextStyle textStyle = null;
            foreach (var style in dxfDocument.TextStyles)
            {
                textStyle = style;
                break;
            }
            
            //Drawing Text Information
            centerPoint.Y = centerPoint.Y - basePlateInput.Bp / 2 - 15;
            dxfDocument.AddEntity(CreateText(textStyle, $"Bolt:{basePlateInput.nb}{basePlateInput.AnchorBolt.Name} {basePlateInput.AnchorBolt.Projection(basePlateInput.GroutThickness, designResult.t_req)}", AciColor.Magenta, centerPoint));

            centerPoint.Y -= 8;
            dxfDocument.AddEntity(CreateText(textStyle, $"Section:{basePlateInput.Sec.Name}", AciColor.Magenta, centerPoint));

            centerPoint.Y -= 8;
            dxfDocument.AddEntity(CreateText(textStyle, $"THK:{(designResult.t_req * 10)} mm", AciColor.Magenta, centerPoint));

            centerPoint.Y -= 8;
            dxfDocument.AddEntity(CreateText(textStyle, $"Main Rebars:{basePlateInput.nrN}X{basePlateInput.nrB}Φ{(basePlateInput.dr)}", AciColor.Magenta, centerPoint));
            
            centerPoint.Y -= 8;
            dxfDocument.AddEntity(CreateText(textStyle, $"Stirrups:Φ{(basePlateInput.drs * 10)}@{(basePlateInput.rsS * 10)} mm", AciColor.Magenta, centerPoint));


            centerPoint.Y -= 8;
            dxfDocument.AddEntity(CreateText(textStyle, $"Stiffener:{(basePlateInput.StiffnerType == 0 ? "Not Required" : "Required")}", AciColor.Magenta, centerPoint));

            dxfDocument.Save(FileName);
        }

        private static IEnumerable<PolylineVertex> CreateRectangle(Vector3 centerPoint, double width, double height)
        {
            var polylineVertices = new List<PolylineVertex>
            {
                new PolylineVertex(centerPoint.X - width / 2, centerPoint.Y - height / 2, centerPoint.Z),
                new PolylineVertex(centerPoint.X + width / 2, centerPoint.Y - height / 2, centerPoint.Z),
                new PolylineVertex(centerPoint.X + width / 2, centerPoint.Y + height / 2, centerPoint.Z),
                new PolylineVertex(centerPoint.X - width / 2, centerPoint.Y + height / 2, centerPoint.Z),
                new PolylineVertex(centerPoint.X - width / 2, centerPoint.Y - height / 2, centerPoint.Z)
            };
            
            return polylineVertices;
        }

        private static IEnumerable<PolylineVertex> CreateHexagonal(Vector3 centerPoint, double length, double defaultAngle = 0)
        {
            return CreatePolynomial(centerPoint, length, 6, defaultAngle);
        }

        private static IEnumerable<PolylineVertex> CreatePolynomial(Vector3 centerPoint, double length, int sides, double defaultAngle = 0)
        {
            var angle = 2 * Math.PI / sides;
            var polylineVertexList = new List<PolylineVertex>();

            defaultAngle += angle / 2;
            length = (length / 2) / Math.Cos(defaultAngle);
            
            for (var i = 0; i <= sides; i++)
            {
                polylineVertexList.Add(new PolylineVertex(centerPoint.X + length * Math.Cos(angle * i), centerPoint.Y + length * Math.Sin(angle * i), centerPoint.Z));
            }

            return polylineVertexList;
        }

        private static IEnumerable<PolylineVertex> CreateSection(Vector3 centerPoint, SectionI section)
        {
            var polylineVertexList = new List<PolylineVertex>
            {
                new PolylineVertex(centerPoint.X - section.h / 2, centerPoint.Y - section.bf / 2, centerPoint.Z),           //01
                new PolylineVertex(centerPoint.X - section.h / 2 + section.tf, centerPoint.Y - section.bf / 2, centerPoint.Z),  //02
                new PolylineVertex(centerPoint.X - section.h / 2 + section.tf, centerPoint.Y - section.tw / 2, centerPoint.Z),  //03
                new PolylineVertex(centerPoint.X + section.h / 2 - section.tf, centerPoint.Y - section.tw / 2, centerPoint.Z),  //04
                new PolylineVertex(centerPoint.X + section.h / 2 - section.tf, centerPoint.Y - section.bf / 2, centerPoint.Z),  //05
                new PolylineVertex(centerPoint.X + section.h / 2, centerPoint.Y - section.bf / 2, centerPoint.Z),           //06
                new PolylineVertex(centerPoint.X + section.h / 2, centerPoint.Y + section.bf / 2, centerPoint.Z),           //07
                new PolylineVertex(centerPoint.X + section.h / 2 - section.tf, centerPoint.Y + section.bf / 2, centerPoint.Z),  //08
                new PolylineVertex(centerPoint.X + section.h / 2 - section.tf, centerPoint.Y + section.tw / 2, centerPoint.Z),  //09
                new PolylineVertex(centerPoint.X - section.h / 2 + section.tf, centerPoint.Y + section.tw / 2, centerPoint.Z),  //10
                new PolylineVertex(centerPoint.X - section.h / 2 + section.tf, centerPoint.Y + section.bf / 2, centerPoint.Z),  //11
                new PolylineVertex(centerPoint.X - section.h / 2, centerPoint.Y + section.bf / 2, centerPoint.Z),           //12
                new PolylineVertex(centerPoint.X - section.h / 2, centerPoint.Y - section.bf / 2, centerPoint.Z)            //13, 1
            };

            return polylineVertexList.ToArray();
        }

        private static Text CreateText(TextStyle textStyle, string textValue, AciColor color, Vector3 leftPosition)
        {
            //var textStyle = new TextStyle("Standard")
            //{
            //    WidthFactor = 1,
            //    ObliqueAngle = 0,
            //    IsBackward = false,
            //    IsUpsideDown = false,
            //    IsVertical = false
            //};

            var text = new Text
            {
                Color = AciColor.Magenta,
                Height = 5,
                Style = textStyle,
                Position = leftPosition,
                Rotation = 0,
                Alignment = TextAlignment.MiddleLeft,
                Value = textValue
            };

            return text;
        }

    }
}
