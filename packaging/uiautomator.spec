Name:       uiautomator
Summary:    UIAutomator Service
Version:    0.1.1
Release:    1
Group:      Framework/system
License:    Apache
Source0:    %{name}-%{version}.tar.gz

BuildRequires:  pkgconfig(elementary)
BuildRequires:  pkgconfig(ecore)
BuildRequires:  pkgconfig(dlog)
BuildRequires:  pkgconfig(glib-2.0)
BuildRequires:  pkgconfig(dbus-glib-1)
BuildRequires:  pkgconfig(gobject-2.0)
BuildRequires:  pkgconfig(gio-2.0)
BuildRequires:  pkgconfig(gthread-2.0)
BuildRequires:  pkgconfig(jsoncpp)
BuildRequires:  pkgconfig(edbus)
BuildRequires:  pkgconfig(systemd)
BuildRequires:  cmake
BuildRequires:  boost-devel

Requires(preun): /usr/bin/systemctl
#Requires(post): sys-assert
Requires(post): /usr/bin/systemctl
Requires(postun): /usr/bin/systemctl

%description
UIAutomator Service

%prep
%setup -q

%build
export CFLAGS+=" -fPIC"
export LDFLAGS+="-Wl,--rpath=%{PREFIX} -Wl,--as-needed"

cmake -DCMAKE_INSTALL_PREFIX=%{_prefix} UIAutomator 

make %{?jobs:-j%jobs}

%install
rm -rf %{buildroot}
%make_install

mkdir -p %{buildroot}%{_libdir}/systemd/system/graphical.target.wants/
ln -s ../uiautomator.service %{buildroot}%{_libdir}/systemd/system/graphical.target.wants/ 

#mkdir -p %{buildroot}%{_datadir}/license

%post
systemctl daemon-reload
if [ $1 == 1 ]; then
    systemctl restart uiautomator.service
fi

%preun
if [ $1 == 0 ]; then
    systemctl stop uiautomator.service
fi

%postun
systemctl daemon-reload

%files -n uiautomator
%{_bindir}/uiautomator
%{_libdir}/systemd/system/uiautomator.service
%{_libdir}/systemd/system/graphical.target.wants/uiautomator.service
%{_datadir}/dbus-1/services/org.tizen.system.uiautomator.service
%{_datadir}/license/uiautomator
%{_sysconfdir}/smack/accesses.d/uiautomator.rule

%manifest uiautomator.manifest
#%defattr(-,root,root,-)
#%{_bindir}/uiautomator