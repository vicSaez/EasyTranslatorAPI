namespace EasyTranslatorAPI.Clients
{
    using System.Collections.Generic;

    public class Sentence
    {
        public string trans { get; set; }
        public string orig { get; set; }
        public int backend { get; set; }
    }

    public class Entry
    {
        public string word { get; set; }
        public List<string> reverse_translation { get; set; }
        public double score { get; set; }
    }

    public class Dict
    {
        public string pos { get; set; }
        public List<string> terms { get; set; }
        public List<Entry> entry { get; set; }
        public string base_form { get; set; }
        public int pos_enum { get; set; }
    }

    public class Alternative
    {
        public string word_postproc { get; set; }
        public int score { get; set; }
        public bool has_preceding_space { get; set; }
        public bool attach_to_next_token { get; set; }
    }

    public class Srcunicodeoffset
    {
        public int begin { get; set; }
        public int end { get; set; }
    }

    public class AlternativeTranslation
    {
        public string src_phrase { get; set; }
        public List<Alternative> alternative { get; set; }
        public List<Srcunicodeoffset> srcunicodeoffsets { get; set; }
        public string raw_src_segment { get; set; }
        public int start_pos { get; set; }
        public int end_pos { get; set; }
    }

    public class LdResult
    {
        public List<string> srclangs { get; set; }
        public List<double> srclangs_confidences { get; set; }
        public List<string> extended_srclangs { get; set; }
    }

    public class Features
    {
        public int gender { get; set; }
        public int number { get; set; }
    }

    public class QueryInflection
    {
        public string written_form { get; set; }
        public Features features { get; set; }
    }

    public class GoogleTranslateResponse
    {
        public List<Sentence> sentences { get; set; }
        public List<Dict> dict { get; set; }
        public string src { get; set; }
        public List<AlternativeTranslation> alternative_translations { get; set; }
        public double confidence { get; set; }
        public LdResult ld_result { get; set; }
        public List<QueryInflection> query_inflections { get; set; }
    }
}
