﻿using HoneybeeSchema;
using System.Collections.Generic;

namespace SAM.Analytical.LadybugTools
{
    public static partial class Convert
    {
        public static Space ToSAM(this Room room, IEnumerable<InternalCondition> internalConditions = null)
        {
            if(room == null)
            {
                return null;
            }

            Geometry.Spatial.Point3D location = null;
            double area = double.NaN;
            double volume = double.NaN;

            Geometry.Spatial.Shell shell = Geometry.LadybugTools.Query.Shell(room);
            if(shell != null)
            {
                location = shell.InternalPoint3D();
                area = Geometry.Spatial.Query.Area(shell, 0.1);
                volume = Geometry.Spatial.Query.Volume(shell);
            }

            Space result = new Space(room.DisplayName, location);
            if (!double.IsNaN(area))
            {
                result.SetValue(SpaceParameter.Area, area);
            }

            if(!double.IsNaN(volume))
            {
                result.SetValue(SpaceParameter.Volume, volume);
            }

            string programType = room.Properties?.Energy?.ProgramType;
            if(!string.IsNullOrWhiteSpace(programType))
            {
                InternalCondition internalCondition = null;
                if (internalConditions != null)
                {
                    foreach(InternalCondition internalCondition_Temp in internalConditions)
                    {
                        if(internalCondition_Temp.Name == programType)
                        {
                            internalCondition = internalCondition_Temp;
                            break;
                        }
                    }
                }

                if(internalCondition == null)
                {
                    internalCondition = new InternalCondition(programType);
                }

                if(internalCondition != null && !double.IsNaN(volume))
                {
                    if(internalCondition.TryGetValue(InternalConditionParameter.FlowPerExteriorArea, out double flowPerExteriorArea))
                    {
                        internalCondition = new InternalCondition(System.Guid.NewGuid(), internalCondition);
                        double exteriorArea = Geometry.LadybugTools.Query.ExteriorArea(room);

                        double flow = flowPerExteriorArea * exteriorArea;

                        internalCondition.SetValue(Analytical.InternalConditionParameter.InfiltrationAirChangesPerHour, flow / volume * 3600);
                    }
                }

                result.InternalCondition = internalCondition;
            }

            return result;
        }
    }
}