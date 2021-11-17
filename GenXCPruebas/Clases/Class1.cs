using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.DatabaseServices;
using Application = Autodesk.AutoCAD.ApplicationServices.Application;

namespace GenXCPruebas.Clases
{
    class Class1
    {
            
        public class Point
        {
            public Point3d LatLongFromPoint2(Point3d P)
            {

                var doc = Application.DocumentManager.MdiActiveDocument;

                var ed = doc.Editor;
                var db = doc.Database;

                var lonlat = TranslateGeoPoint(db, P, true);
                var p = new Point3d(lonlat.X, lonlat.Y, 0);

                return p;
            }

            //public Point2d LatLongFromPoint2(Point2d P)
            //{
            //    var doc = Application.DocumentManager.MdiActiveDocument;

            //    var ed = doc.Editor;
            //    var db = doc.Database;

            //    var lonlat = TranslateGeoPoint(db, P, true);
            //    var p = new Point2d(lonlat.X, lonlat.Y);

            //    return p;
            //}

            public Point3d LatLongFromPoint2d(Point3d P)
            {
                var doc = Application.DocumentManager.MdiActiveDocument;

                var ed = doc.Editor;
                var db = doc.Database;

                var lonlat = TranslateGeoPoint(db, P, true);
                var p = new Point3d(lonlat.X, lonlat.Y, 0);

                return p;
            }

            private Point3d TranslateGeoPoint(Database db, Point3d inPt, bool fromDwg)
            {
                using (var tr = db.TransactionManager.StartOpenCloseTransaction())
                {
                    // Get the drawing's GeoLocation object

                    var gd = tr.GetObject(db.GeoDataObject, OpenMode.ForRead) as GeoLocationData;

                    // Get the output point...
                    // dwg2lonlat if fromDwg is true,
                    // lonlat2dwg otherwise

                    var outPt = (fromDwg ? gd.TransformToLonLatAlt(inPt) : gd.TransformFromLonLatAlt(inPt));

                    tr.Commit();

                    return outPt;
                }
            }

            public Point3d PointFromLatLong(Point3d Point)
            {
                var doc = Application.DocumentManager.MdiActiveDocument;
                var db = doc.Database;

                // Translate the lat-lon to a drawing point

                var dwgPt = TranslateGeoPoint(db, Point, false);
                return dwgPt;
            }

            public Point2d Point2FromLatLon(Point3d Point)
            {
                var doc = Application.DocumentManager.MdiActiveDocument;
                var db = doc.Database;

                // Translate the lat-lon to a drawing point

                var dwgPt = TranslateGeoPoint(db, Point, false);
                Point2d p2 = new Point2d(dwgPt.X, dwgPt.Y);

                return p2;
            }

            public string getBetween(string Data, string St, string En)
            {
                int Start, End;
                if (Data.Contains(St) && Data.Contains(En))
                {
                    Start = Data.IndexOf(St, 0) + St.Length;
                    End = Data.IndexOf(En, Start);
                    return Data.Substring(Start, End - Start);
                }
                else
                {
                    return "";
                }
            }

        }
    }
}
