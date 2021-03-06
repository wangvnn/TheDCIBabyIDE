﻿using NJasmine;
using KimHaiQuang.TheDCIBabyIDE.Domain.Operation;
using KimHaiQuang.TheDCIBabyIDE.Domain.Data.Settings;

namespace TheDCIBabyIDE.Test.DomainTest.DataTest
{
    public class ParseDCIContextFileTest : GivenWhenThenFixture
    {
        public override void Specify()
        {
            given("A DCI Context file and IDE Settings set to Injectionless Context File Type", () => {

                string contextFile = TestInfo.FrontLoadOperation;
                var IDESettings = new BabyIDESettings();
                IDESettings.ContextFileTypeSettings = BabyIDESettings.ContextFiletype.ContextFiletype_Injectionless;

                when("parse dci context file", () => {

                    var dciContext = new ContextFileParsingContext(IDESettings).Parse(contextFile);

                    then("the dciContext should have correct info: roles, usecase...", () => {

                        expect(() => dciContext.Name.EndsWith("FrontLoadContext"));
                        expect(() => dciContext.UsecaseSpan.Length > 0);
                        expect(() => dciContext.CodeSpan.Length > 0);

                        expect(() => dciContext.Roles.Count == 5);

                        expect(() => dciContext.Roles["UnPlannedActivity"].Interface.Signatures.Count > 0);
                        expect(() => dciContext.Roles["UnPlannedActivity"].Methods.Count > 0);
                    }); 
                });
            });
        }
    }
}
