"""Repository-specific classification decisions for SAM_LadybugTools (the only non-shared tool file).

OVERRIDES     : component display name -> (object glyph, op, extra)   extra: None | "plural" | "library" | note
PARAM_OBJECTS : param type key (Goo<X>Param class or typeof(X) name) -> glyph | (glyph, container, plural)
OBJECTS/VERBS : extra noun/verb rules tried before the shared ones (same shapes as SAM's OBJECTS/VERBS)
"""
OVERRIDES = {
    "Honeybee.SAMAnalytical": ("object", "import", None), "SAMAnalytical.HBFace": ("panel", "export", None),
    "SAMAnalytical.HBModel": ("model", "export", None), "SAMAnalytical.HBModelCheck": ("model", "validate", None),
    "SAMAnalytical.ProfileToLBJson": ("profile", "export", None),
    "LBGeometry.SAMGeometry": ("geometry", "import", None), "SAMGeometry.LBGeometry": ("geometry", "export", None),
}
PARAM_OBJECTS = {}
OBJECTS = []
VERBS = []
