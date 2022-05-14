//MIT License

//Copyright (c) 2021 Sean Petrie(Vek17)

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.

using HarmonyLib;

using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.UI.Common;
using Kingmaker.UI.MVVM._VM.CharGen.Phases.FeatureSelector;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Class.LevelUp;
using Kingmaker.UnitLogic.Class.LevelUp.Actions;

using Microsoftenator.Wotr.Common.Blueprints.Extensions;

using System;
using System.Linq;

namespace Microsoftenator.Wotr.Common
{
    public class AddAdditionalRacialFeatures : UnitFactComponentDelegate
    {
        public BlueprintFeatureBaseReference[]? Features;

        public override void OnActivate()
        {
            LevelUpController? controller = Kingmaker.Game.Instance?.LevelUpController;
            if (controller == null) { return; }
            if (controller.State.Mode == LevelUpState.CharBuildMode.Mythic) { return; }
            if (Owner.Descriptor.Progression.CharacterLevel > 1) { return; }
            LevelUpHelper.AddFeaturesFromProgression(controller.State, Owner, Features.Select(f => f.Get()).ToArray(), Owner.Progression.Race, 0);
        }

    }
}
