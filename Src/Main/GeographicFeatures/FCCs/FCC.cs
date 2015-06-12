using System.Collections;

namespace USC.GISResearchLab.Common.GeographicFeatures.FCCs
{
    public class FCC
    {

        public static string FCC_NAME_HIGHWAY = "HIGHWAY";
        public static string FCC_NAME_MAJOR_ROAD = "MAJOR_ROAD";
        public static string FCC_NAME_MINOR_ROAD = "MINOR_ROAD";
        public static string FCC_NAME_LOCAL_ROAD = "LOCAL_ROAD";
        public static string FCC_NAME_RAMP = "RAMP";
        public static string FCC_NAME_FERRY = "FERRY";
        public static string FCC_NAME_RUNWAY = "RUNWAY";
        public static string FCC_NAME_AIRPORT = "AIRPORT";
        public static string FCC_NAME_RAIL = "RAIL";
        public static string FCC_NAME_STADIUM = "STADIUM";
        public static string FCC_NAME_MILITARY = "MILITARY";
        public static string FCC_NAME_CEMETERY = "CEMETERY";
        public static string FCC_NAME_GOLF_COURSE = "GOLF_COURSE";
        public static string FCC_NAME_GOVERNMENT = "GOVERNMENT";
        public static string FCC_NAME_AMUSEMENT = "AMUSEMENT";
        public static string FCC_NAME_MALL = "MALL";
        public static string FCC_NAME_HOSPITAL = "HOSPITAL";


        // FCCs for road types
        public static string[] FCC_LIST_HIGHWAY = new string[] { "A10", "A11", "A12", "A13", "A14", "A15", "A16", "A17", "A18" };
        public static string[] FCC_LIST_MAJOR_ROAD = new string[] { "A20", "A21", "A22", "A23", "A24", "A25", "A26", "A27", "A28" };
        public static string[] FCC_LIST_MINOR_ROAD = new string[] { "A30", "A31", "A32", "A33", "A34", "A35", "A36", "A37", "A38" };
        public static string[] FCC_LIST_LOCAL_ROAD = new string[] { "A40", "A41", "A42", "A43", "A44", "A45", "A46", "A47", "A48", "A60", "A61", "A62", "A70", "A71", "A72", "A73", "A74" };
        public static string[] FCC_LIST_RAMP = new string[] { "A63" };

        // FCCs for ferry types
        public static string[] FCC_LIST_FERRY = new string[] { "A65", "A66", "A68", "A69" };

        // FCCs for airport types
        public static string[] FCC_LIST_RUNWAY = new string[] { "D59" };
        public static string[] FCC_LIST_AIRPORT = new string[] { "D58" };

        // FCCs for rail types
        public static string[] FCC_LIST_RAIL = new string[] { "B00", "B01", "B02", "B03", "B10", "B11", "B12", "B13", "B20", "B21", "B22", "B23" };

        // FCCs for stadium types
        public static string[] FCC_LIST_STADIUM = new string[] { "D67" };

        // FCCs for other landmark types
        public static string[] FCC_LIST_MILITARY = new string[] { "D10" };
        public static string[] FCC_LIST_CEMETERY = new string[] { "D82" };
        public static string[] FCC_LIST_GOLF_COURSE = new string[] { "D81" };
        public static string[] FCC_LIST_GOVERNMENT = new string[] { "D65" };
        public static string[] FCC_LIST_AMUSEMENT = new string[] { "D64" };
        public static string[] FCC_LIST_MALL = new string[] { "D61" };
        public static string[] FCC_LIST_HOSPITAL = new string[] { "D31" };

        public static Hashtable FCCTypeMappings;

        static FCC()
        {
            FCCTypeMappings = new Hashtable();
            FCCTypeMappings.Add(FCC_NAME_AIRPORT, FCC_LIST_AIRPORT);
            FCCTypeMappings.Add(FCC_NAME_AMUSEMENT, FCC_LIST_AMUSEMENT);
            FCCTypeMappings.Add(FCC_NAME_CEMETERY, FCC_LIST_CEMETERY);
            FCCTypeMappings.Add(FCC_NAME_FERRY, FCC_LIST_FERRY);
            FCCTypeMappings.Add(FCC_NAME_GOLF_COURSE, FCC_LIST_GOLF_COURSE);
            FCCTypeMappings.Add(FCC_NAME_GOVERNMENT, FCC_LIST_GOVERNMENT);
            FCCTypeMappings.Add(FCC_NAME_HIGHWAY, FCC_LIST_HIGHWAY);
            FCCTypeMappings.Add(FCC_NAME_HOSPITAL, FCC_LIST_HOSPITAL);
            FCCTypeMappings.Add(FCC_NAME_LOCAL_ROAD, FCC_LIST_LOCAL_ROAD);
            FCCTypeMappings.Add(FCC_NAME_MAJOR_ROAD, FCC_LIST_MAJOR_ROAD);
            FCCTypeMappings.Add(FCC_NAME_MALL, FCC_LIST_MALL);
            FCCTypeMappings.Add(FCC_NAME_MILITARY, FCC_LIST_MILITARY);
            FCCTypeMappings.Add(FCC_NAME_MINOR_ROAD, FCC_LIST_MINOR_ROAD);
            FCCTypeMappings.Add(FCC_NAME_RAIL, FCC_LIST_RAIL);
            FCCTypeMappings.Add(FCC_NAME_RAMP, FCC_LIST_RAMP);
            FCCTypeMappings.Add(FCC_NAME_RUNWAY, FCC_LIST_RUNWAY);
            FCCTypeMappings.Add(FCC_NAME_STADIUM, FCC_LIST_STADIUM);

        }

        public static string AsQuery(string name)
        {
            string ret = "";

            if (name != null && name != "")
            {
                string[] fccList = FCC.ByName(name);

                if (fccList != null && fccList.Length > 0)
                {
                    ret += "(";
                    for (int i = 0; i < fccList.Length; i++)
                    {
                        string fccVal = fccList[i];
                        if (i > 0)
                        {
                            ret += " OR ";
                        }
                        ret += "( " + "\"FCC\"='" + fccVal + "' )";
                    }
                    ret += ")";
                }
            }

            return ret;
        }

        public static string[] ByName(string name)
        {
            string [] ret = null;
            if (FCCTypeMappings.ContainsKey(name))
            {
                ret = (string[])FCCTypeMappings[name];
            }
            return ret;
        }

        public static string[] FCCNames()
        {
            string[] ret = new string[FCCTypeMappings.Keys.Count];
            FCCTypeMappings.Keys.CopyTo(ret, 0);
            return ret;
        }
    }
}
