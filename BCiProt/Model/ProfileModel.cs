using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCiProt.Model
{
    public class ProfileModel
    {
        public TreeModel generalTree { get; set; }
        public TreeModel dataTree { get; set; }
        public TreeModel audioTree { get; set; }
        public TreeModel videoTree { get; set; }
        public TreeModel transcoderTree { get; set; }

        public bool isActive { get; set; }

        public ProfileModel()
        {
            this.generalTree = new TreeModel();
            this.dataTree = new TreeModel();
            this.audioTree = new TreeModel();
            this.videoTree = new TreeModel();
            this.transcoderTree = new TreeModel();
        }
    }
}
