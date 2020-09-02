﻿using Grasshopper.Kernel;
using SAM.Analytical.Grasshopper.LadybugTools.Properties;
using SAM.Core.Grasshopper;
using System;

namespace SAM.Analytical.Grasshopper.LadybugTools
{
    public class SAMAnalyticalHBModel : GH_SAMComponent
    {
        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid => new Guid("1591e2d0-2b21-49dc-b497-5dc5d45e99b7");

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon => Resources.SAM_Honeybee;

        /// <summary>
        /// Initializes a new instance of the SAMGeometryByGHGeometry class.
        /// </summary>
        public SAMAnalyticalHBModel()
          : base("SAMAnalytical.HBModel", "SAMAnalytical.HBModel",
              "SAM Analytical AdjacencyCluster to Ladybug Tools HB Model",
              "SAM", "LadybugTools")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_InputParamManager inputParamManager)
        {
            inputParamManager.AddParameter(new GooAdjacencyClusterParam(), "_adjacencyCluster", "_adjacencyCluster", "SAM Analytical AdjacencyCluster", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_OutputParamManager outputParamManager)
        {
            outputParamManager.AddGenericParameter("HBModel", "HBModel", "Ladybug Tools HB Model", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="dataAccess">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess dataAccess)
        {
            AdjacencyCluster adjacencyCluster = null;

            if (!dataAccess.GetData(0, ref adjacencyCluster) || adjacencyCluster == null)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Invalid data");
                return;
            }

            HoneybeeSchema.Model model = Analytical.LadybugTools.Convert.ToLadybugTools(adjacencyCluster);

            dataAccess.SetData(0, model?.ToJson());
        }
    }
}