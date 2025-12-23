using Teniszklub;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private Teniszklub.Teniszklub klub;
        private Palya palya1;
        private Palya palya2;
        private Palya palya3;
        private Palya palya4;
        private Tag bence;
        private Tag anna;
        private Tag zsolti;
        private Tag lilla;

        [TestInitialize]

        public void Init()
        {
            klub = new Teniszklub.Teniszklub();

            klub.AddPalya(1, Enums.Palya_tipus.fu, false);
            klub.AddPalya(2, Enums.Palya_tipus.muanyag, true);
            klub.AddPalya(3, Enums.Palya_tipus.salak, true);
            klub.AddPalya(4, Enums.Palya_tipus.muanyag, false);

            palya1 = klub.palya.First(p => p.sorszam == 1);
            palya2 = klub.palya.First(p => p.sorszam == 2);
            palya3 = klub.palya.First(p => p.sorszam == 3);
            palya4 = klub.palya.First(p => p.sorszam == 4);

            klub.AddTag("BENCE", Enums.Jatekos_tipus.igazolt_sportolo);
            klub.AddTag("ANNA", Enums.Jatekos_tipus.nyugdijas);
            klub.AddTag("ZSOLTI", Enums.Jatekos_tipus.diak);
            klub.AddTag("LILLA", Enums.Jatekos_tipus.igazolt_sportolo);

            bence = klub.tag.First(t => t.name == "BENCE");
            anna = klub.tag.First(t => t.name == "ANNA");
            zsolti = klub.tag.First(t => t.name == "ZSOLTI");
            lilla = klub.tag.First(t => t.name == "LILLA");
        }

        [TestMethod]
        public void TestCases()
        {
            bence.Palya_foglalas(klub, palya1, new DateTime(2025, 05, 18), 10);

            Assert.AreEqual(1, klub.foglalas.Count, "Hiba1");
            Assert.AreEqual(palya1, klub.foglalas[0].palya, "Hiba2");
            Assert.AreEqual(bence, klub.foglalas[0].tag, "Hiba3");
            Assert.AreEqual(new DateTime(2025, 05, 18), klub.foglalas[0].date, "Hiba4");
            Assert.AreEqual(10, klub.foglalas[0].ido, "Hiba5");
            Assert.IsTrue(palya1.foglalt, "Hiba6");
        
            anna.Palya_foglalas(klub, palya2, new DateTime(2025, 05, 28), 8);

            Assert.AreEqual(2, klub.foglalas.Count, "Hiba7");
            Assert.AreEqual(palya2, klub.foglalas[1].palya, "Hiba8");
            Assert.AreEqual(anna, klub.foglalas[1].tag, "Hiba9");
            Assert.AreEqual(new DateTime(2025, 05, 28), klub.foglalas[1].date, "Hiba10");
            Assert.AreEqual(8, klub.foglalas[1].ido, "Hiba11");
            Assert.IsTrue(palya2.foglalt, "Hiba12");
        
            zsolti.Palya_foglalas(klub, palya3, new DateTime(2025, 07, 18), 7);

            Assert.AreEqual(3, klub.foglalas.Count, "Hiba13");
            Assert.AreEqual(palya3, klub.foglalas[2].palya, "Hiba14");
            Assert.AreEqual(zsolti, klub.foglalas[2].tag, "Hiba15");
            Assert.AreEqual(new DateTime(2025, 07, 18), klub.foglalas[2].date, "Hiba16");
            Assert.AreEqual(7, klub.foglalas[2].ido, "Hiba17");
            Assert.IsTrue(palya3.foglalt, "Hiba18");
        
            lilla.Palya_foglalas(klub, palya4, new DateTime(2025, 08, 28), 19);

            Assert.AreEqual(4, klub.foglalas.Count, "Hiba19");
            Assert.AreEqual(palya4, klub.foglalas[3].palya, "Hiba20");
            Assert.AreEqual(lilla, klub.foglalas[3].tag, "Hiba21");
            Assert.AreEqual(new DateTime(2025, 08, 28), klub.foglalas[3].date, "Hiba22");
            Assert.AreEqual(19, klub.foglalas[3].ido, "Hiba23");
            Assert.IsTrue(palya4.foglalt, "Hiba24");
        
            Assert.AreEqual(3500, Teniszklub.Program.Mennyibe(klub, bence, new DateTime(2025, 05, 18)), "Hiba25");
            Assert.AreEqual(1440, Teniszklub.Program.Mennyibe(klub, anna, new DateTime(2025, 05, 28)), "Hiba26");
            Assert.AreEqual(2880, Teniszklub.Program.Mennyibe(klub, zsolti, new DateTime(2025, 07, 18)), "Hiba27");
            Assert.AreEqual(1400, Teniszklub.Program.Mennyibe(klub, lilla, new DateTime(2025, 08, 28)), "Hiba28");
        
            Assert.AreEqual(9220, Teniszklub.Program.Klub_bevetel(klub, new DateTime(2025, 05, 17), new DateTime(2025, 08, 29)), "Hiba29");
        
            klub.RemoveTag("ANNA");

            Assert.AreEqual(3, klub.tag.Count, "Hiba30");
            Assert.IsFalse(klub.tag.Any(t => t.name == "ANNA"), "Hiba31");
        
            klub.RemPalya(1);

            Assert.AreEqual(3, klub.palya.Count, "Hiba32");
            Assert.IsFalse(klub.palya.Any(t => t.sorszam == 1), "Hiba33");
        
            zsolti.Palya_lemondas(klub, palya3, new DateTime(2025, 07, 18), 7, new DateTime(2025, 04, 28));

            Assert.AreEqual(3, klub.foglalas.Count, "Hiba33");
            Assert.IsFalse(palya3.foglalt, "Hiba34");

            var res = Teniszklub.Program.FeltSearchPalya(klub, Enums.Palya_tipus.salak);

            Assert.IsTrue(res.Count != 0, "Hiba35");

            var res2 = Teniszklub.Program.FeltSearchFoglalasok(klub, lilla, new DateTime(2025, 08, 28));

            Assert.IsTrue(res2.Count != 0, "Hiba36");
        }
        public void TestMethod1()
        {
        }
    }
}