# Initializers
MONO_BASE_PATH = 
MONO_ADDINS_PATH =

# Install Paths
DEFAULT_INSTALL_DIR = $(pkglibdir)
EXTENSIONS_INSTALL_DIR = $(DEFAULT_INSTALL_DIR)/Extensions

# External libraries to link against, generated from configure
LINK_SYSTEM = -r:System
LINK_MONO_POSIX = -r:Mono.Posix
LINK_CAIRO = -r:Mono.Cairo
LINK_GTK = $(GTKSHARP_LIBS)
LINK_GIO = $(GIOSHARP_LIBS)
LINK_MONO_ADDINS_DEPS = $(MONO_ADDINS_LIBS)
LINK_MONO_ADDINS_SETUP_DEPS = $(MONO_ADDINS_SETUP_LIBS)
LINK_MONO_ADDINS_GUI_DEPS = $(MONO_ADDINS_GUI_LIBS)

DIR_BIN = $(top_builddir)/bin

# TagLib
LINK_TAGLIB = -r:$(DIR_BIN)/TagLib.dll

# Mono.Data
REF_SQLITE = -r:System -r:System.Data -r:System.Transactions
LINK_SQLITE = -r:System.Data -r:$(DIR_BIN)/Mono.Data.Sqlite.dll

# Hyena
REF_HYENA = $(LINK_SYSTEM) $(LINK_SQLITE) $(LINK_MONO_POSIX)
LINK_HYENA = -r:$(DIR_BIN)/Hyena.dll
LINK_HYENA_DEPS = $(REF_HYENA) $(LINK_HYENA)

# Hyena.Gui
REF_HYENA_GUI = $(LINK_SYSTEM) $(LINK_SQLITE) $(LINK_MONO_POSIX) $(LINK_GTK) $(LINK_CAIRO) $(LINK_HYENA)
LINK_HYENA_GUI = -r:$(DIR_BIN)/Hyena.Gui.dll
LINK_HYENA_GUI_DEPS = $(REF_HYENA_GUI) $(LINK_HYENA_GUI)

# Core
REF_TRIPOD_CORE = $(LINK_MONO_POSIX) $(LINK_HYENA) $(LINK_HYENA_GUI) $(LINK_GTK) $(LINK_CAIRO) $(LINK_GIO) $(LINK_MONO_ADDINS_DEPS) $(LINK_TAGLIB)
LINK_TRIPOD_CORE = -r:$(DIR_BIN)/Tripod.Core.dll
LINK_TRIPOD_CORE_DEPS = $(REF_TRIPOD_CORE) $(LINK_TRIPOD_CORE)

# Core GUI
REF_TRIPOD_GUI = $(LINK_TRIPOD_CORE_DEPS)
LINK_TRIPOD_GUI = -r:$(DIR_BIN)/Tripod.Gui.dll
LINK_TRIPOD_GUI_DEPS = $(REF_TRIPOD_GUI) $(LINK_TRIPOD_GUI)

# Clients
REF_FLASHUNIT = $(LINK_TRIPOD_CORE_DEPS) $(LINK_TRIPOD_GUI_DEPS)

# Cute hack to replace a space with something
colon:= :
empty:=
space:= $(empty) $(empty)

# Build path to allow running uninstalled
RUN_PATH = $(subst $(space),$(colon), $(MONO_BASE_PATH))

