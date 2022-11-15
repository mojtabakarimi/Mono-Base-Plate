using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_Plate_Engine.Design.Sections.Interfaces
{
    public interface ISectionI : ISection
    {
        double d { get; }

        double h { get; }
        double d1 { get; }
        double bf { get; }
        double tf { get; }
        double tw { get; }
        double r { get; }

        ////double d { get; }
        //double h_o { get; }
        //double t_fBot { get; }

        //double t_fTop { get; }

        ////double tf { get;  }
        //double b_fBot { get; }

        //double b_fTop { get; }

        ////double t_w { get;  }
        //double h_web { get; }
        //double FilletDistance { get; }
    }
}
