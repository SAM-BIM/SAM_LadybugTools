// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors

using Grasshopper.Kernel;
using SAM.Analytical.Grasshopper.LadybugTools.Properties;
using SAM.Core;
using SAM.Core.Grasshopper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Analytical.LadybugTools
{
    public class SAMAnalyticalHoneybeeCheck : GH_SAMVariableOutputParameterComponent
    {
        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid => new Guid("35ab1b3f-10c2-4a23-8755-17edcfe93608");

        /// <summary>
        /// The latest version of this component
        /// </summary>
        public override string LatestComponentVersion => "1.0.1";

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon => Resources.SAM_Honeybee;

        /// <summary>
        /// Initializes a new instance of the SAM_point3D class.
        /// </summary>
        public SAMAnalyticalHoneybeeCheck()
          : base("SAMAnalytical.HBModelCheck", "SAMAnalytical.HBModelCheck",
              "Check Honeybee object agains Honeybee schema",
              "SAM", "LadybugTools")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override GH_SAMParam[] Inputs
        {
            get
            {
                List<GH_SAMParam> result = new List<GH_SAMParam>();
                result.Add(new GH_SAMParam(new global::Grasshopper.Kernel.Parameters.Param_String() { Name = "_json", NickName = "_json", Description = "Honeybee object in Json", Access = GH_ParamAccess.item }, ParamVisibility.Binding));

                global::Grasshopper.Kernel.Parameters.Param_Boolean param_Boolean = new global::Grasshopper.Kernel.Parameters.Param_Boolean() { Name = "_run", NickName = "_run", Description = "Run", Access = GH_ParamAccess.item };
                param_Boolean.SetPersistentData(false);
                result.Add(new GH_SAMParam(param_Boolean, ParamVisibility.Binding));

                return result.ToArray();
            }
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override GH_SAMParam[] Outputs
        {
            get
            {
                List<GH_SAMParam> result = new List<GH_SAMParam>();
                result.Add(new GH_SAMParam(new GooLogParam() { Name = "Log", NickName = "Log", Description = "SAM Log", Access = GH_ParamAccess.item }, ParamVisibility.Binding));
                result.Add(new GH_SAMParam(new GooLogParam() { Name = "Messages", NickName = "Messages", Description = "SAM Log with Messages", Access = GH_ParamAccess.item }, ParamVisibility.Binding));
                return result.ToArray();
            }
        }

        protected override void SolveInstance(IGH_DataAccess dataAccess)
        {
            bool run = false;
            int index = Params.IndexOfInputParam("_run");
            if (index == -1 || !dataAccess.GetData(index, ref run) || !run)
                return;

            string json = null;
            index = Params.IndexOfInputParam("_json");
            if (index == -1 || !dataAccess.GetData(index, ref json))
                return;

            Log log = null;
            try
            {
                HoneybeeSchema.IDdBaseModel iDdBaseModel = HoneybeeSchema.IDdBaseModel.FromJson(json);
                log = Create.Log(iDdBaseModel as dynamic);
            }
            catch
            {
                int logIndex = Params.IndexOfOutputParam("Log");
                if (logIndex != -1)
                {
                    dataAccess.SetData(logIndex, null);
                }
                int messagesIndex = Params.IndexOfOutputParam("Messages");
                if (messagesIndex != -1)
                {
                    dataAccess.SetData(messagesIndex, null);
                }
                return;
            }

            if (log == null)
                log = new Log();

            if (log.Count() == 0)
                log.Add("All good! You can switch off your computer and go home now.");

            index = Params.IndexOfOutputParam("Log");
            if (index != -1)
            {
                dataAccess.SetData(index, log.Filter(new LogRecordType[] { LogRecordType.Error, LogRecordType.Warning, LogRecordType.Undefined }));
            }

            index = Params.IndexOfOutputParam("Messages");
            if (index != -1)
            {
                dataAccess.SetData(index, log.Filter(new LogRecordType[] { LogRecordType.Message }));
            }
        }
    }
}
