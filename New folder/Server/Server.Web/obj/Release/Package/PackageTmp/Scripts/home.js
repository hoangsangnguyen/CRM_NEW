/*!
 * Webflow: Front-end site library
 * @license MIT
 * Inline scripts may access the api using an async handler:
 *   var Webflow = Webflow || [];
 *   Webflow.push(readyFunction);
 */
! function (t) {
    function e(i) {
        if (n[i]) return n[i].exports;
        var r = n[i] = {
            i: i,
            l: !1,
            exports: {}
        };
        return t[i].call(r.exports, r, r.exports, e), r.l = !0, r.exports
    }
    var n = {};
    e.m = t, e.c = n, e.d = function (t, n, i) {
        e.o(t, n) || Object.defineProperty(t, n, {
            configurable: !1,
            enumerable: !0,
            get: i
        })
    }, e.n = function (t) {
        var n = t && t.__esModule ? function () {
            return t.default
        } : function () {
            return t
        };
        return e.d(n, "a", n), n
    }, e.o = function (t, e) {
        return Object.prototype.hasOwnProperty.call(t, e)
    }, e.p = "", e(e.s = 4)
}([function (t, e, n) {
    function i(t) {
        u.env() && (v(t.design) && h.on("__wf_design", t.design), v(t.preview) && h.on("__wf_preview", t.preview)), v(t.destroy) && h.on("__wf_destroy", t.destroy), t.ready && v(t.ready) && function (t) {
            if (w) return void t.ready();
            if (m.contains(l, t.ready)) return;
            l.push(t.ready)
        }(t)
    }

    function r(t) {
        v(t.design) && h.off("__wf_design", t.design), v(t.preview) && h.off("__wf_preview", t.preview), v(t.destroy) && h.off("__wf_destroy", t.destroy), t.ready && v(t.ready) && function (t) {
            l = m.filter(l, function (e) {
                return e !== t.ready
            })
        }(t)
    }

    function o(t, e) {
        var n = [],
            i = {};
        return i.up = m.throttle(function (t) {
            m.each(n, function (e) {
                e(t)
            })
        }), t && e && t.on(e, i.up), i.on = function (t) {
            "function" == typeof t && (m.contains(n, t) || n.push(t))
        }, i.off = function (t) {
            n = arguments.length ? m.filter(n, function (e) {
                return e !== t
            }) : []
        }, i
    }

    function a(t) {
        v(t) && t()
    }

    function s() {
        O && (O.reject(), h.off("load", O.resolve)), O = new d.Deferred, h.on("load", O.resolve)
    }
    var u = {},
        c = {},
        l = [],
        f = window.Webflow || [],
        d = window.jQuery,
        h = d(window),
        p = d(document),
        v = d.isFunction,
        m = u._ = n(6),
        g = n(2) && d.tram,
        w = !1,
        b = !1;
    g.config.hideBackface = !1, g.config.keepInherited = !0, u.define = function (t, e, n) {
        c[t] && r(c[t]);
        var o = c[t] = e(d, m, n) || {};
        return i(o), o
    }, u.require = function (t) {
        return c[t]
    }, u.push = function (t) {
        w ? v(t) && t() : f.push(t)
    }, u.env = function (t) {
        var e = window.__wf_design,
            n = void 0 !== e;
        return t ? "design" === t ? n && e : "preview" === t ? n && !e : "slug" === t ? n && window.__wf_slug : "editor" === t ? window.WebflowEditor : "test" === t ? window.__wf_test : "frame" === t ? window !== window.top : void 0 : n
    };
    var y = navigator.userAgent.toLowerCase(),
        x = u.env.touch = "ontouchstart" in window || window.DocumentTouch && document instanceof window.DocumentTouch,
        k = u.env.chrome = /chrome/.test(y) && /Google/.test(navigator.vendor) && parseInt(y.match(/chrome\/(\d+)\./)[1], 10),
        _ = u.env.ios = /(ipod|iphone|ipad)/.test(y);
    u.env.safari = /safari/.test(y) && !k && !_;
    var T;
    x && p.on("touchstart mousedown", function (t) {
        T = t.target
    }), u.validClick = x ? function (t) {
        return t === T || d.contains(t, T)
    } : function () {
        return !0
    };
    var z = "resize.webflow orientationchange.webflow load.webflow";
    u.resize = o(h, z), u.scroll = o(h, "scroll.webflow resize.webflow orientationchange.webflow load.webflow"), u.redraw = o(), u.location = function (t) {
        window.location = t
    }, u.env() && (u.location = function () { }), u.ready = function () {
        w = !0, b ? (b = !1, m.each(c, i)) : m.each(l, a), m.each(f, a), u.resize.up()
    };
    var O;
    u.load = function (t) {
        O.then(t)
    }, u.destroy = function (t) {
        t = t || {}, b = !0, h.triggerHandler("__wf_destroy"), null != t.domready && (w = t.domready), m.each(c, r), u.resize.off(), u.scroll.off(), u.redraw.off(), l = [], f = [], "pending" === O.state() && s()
    }, d(u.ready), s(), t.exports = window.Webflow = u
}, function (t, e, n) {
    "use strict";

    function i(t, e) {
        var n = document.createEvent("CustomEvent");
        n.initCustomEvent(e, !0, !0, null), t.dispatchEvent(n)
    }
    var r = n(3),
        o = window.jQuery,
        a = {},
        s = {
            reset: function (t, e) {
                r.triggers.reset(t, e)
            },
            intro: function (t, e) {
                r.triggers.intro(t, e), i(e, "COMPONENT_ACTIVE")
            },
            outro: function (t, e) {
                r.triggers.outro(t, e), i(e, "COMPONENT_INACTIVE")
            }
        };
    a.triggers = {}, a.types = {
        INTRO: "w-ix-intro.w-ix",
        OUTRO: "w-ix-outro.w-ix"
    }, o.extend(a.triggers, s), t.exports = a
}, function (t, e) {
    var n = "function" == typeof Symbol && "symbol" == typeof Symbol.iterator ? function (t) {
        return typeof t
    } : function (t) {
        return t && "function" == typeof Symbol && t.constructor === Symbol && t !== Symbol.prototype ? "symbol" : typeof t
    };
    window.tram = function (t) {
        function e(t, e) {
            return (new $.Bare).init(t, e)
        }

        function i(t) {
            return t.replace(/[A-Z]/g, function (t) {
                return "-" + t.toLowerCase()
            })
        }

        function r(t) {
            var e = parseInt(t.slice(1), 16);
            return [e >> 16 & 255, e >> 8 & 255, 255 & e]
        }

        function o(t, e, n) {
            return "#" + (1 << 24 | t << 16 | e << 8 | n).toString(16).slice(1)
        }

        function a() { }

        function s(t, e, n) {
            if (void 0 !== e && (n = e), void 0 === t) return n;
            var i = n;
            return Y.test(t) || !G.test(t) ? i = parseInt(t, 10) : G.test(t) && (i = 1e3 * parseFloat(t)), 0 > i && (i = 0), i == i ? i : n
        }

        function u(t) {
            H.debug && window && window.console.warn(t)
        }
        var c = function (t, e, i) {
            function r(t) {
                return "object" == (void 0 === t ? "undefined" : n(t))
            }

            function o(t) {
                return "function" == typeof t
            }

            function a() { }

            function s(n, u) {
                function c() {
                    var t = new l;
                    return o(t.init) && t.init.apply(t, arguments), t
                }

                function l() { }
                u === i && (u = n, n = Object), c.Bare = l;
                var f, d = a[t] = n[t],
                    h = l[t] = c[t] = new a;
                return h.constructor = c, c.mixin = function (e) {
                    return l[t] = c[t] = s(c, e)[t], c
                }, c.open = function (t) {
                    if (f = {}, o(t) ? f = t.call(c, h, d, c, n) : r(t) && (f = t), r(f))
                        for (var i in f) e.call(f, i) && (h[i] = f[i]);
                    return o(h.init) || (h.init = n), c
                }, c.open(u)
            }
            return s
        }("prototype", {}.hasOwnProperty),
            l = {
                ease: ["ease", function (t, e, n, i) {
                    var r = (t /= i) * t,
                        o = r * t;
                    return e + n * (-2.75 * o * r + 11 * r * r + -15.5 * o + 8 * r + .25 * t)
                }],
                "ease-in": ["ease-in", function (t, e, n, i) {
                    var r = (t /= i) * t,
                        o = r * t;
                    return e + n * (-1 * o * r + 3 * r * r + -3 * o + 2 * r)
                }],
                "ease-out": ["ease-out", function (t, e, n, i) {
                    var r = (t /= i) * t,
                        o = r * t;
                    return e + n * (.3 * o * r + -1.6 * r * r + 2.2 * o + -1.8 * r + 1.9 * t)
                }],
                "ease-in-out": ["ease-in-out", function (t, e, n, i) {
                    var r = (t /= i) * t,
                        o = r * t;
                    return e + n * (2 * o * r + -5 * r * r + 2 * o + 2 * r)
                }],
                linear: ["linear", function (t, e, n, i) {
                    return n * t / i + e
                }],
                "ease-in-quad": ["cubic-bezier(0.550, 0.085, 0.680, 0.530)", function (t, e, n, i) {
                    return n * (t /= i) * t + e
                }],
                "ease-out-quad": ["cubic-bezier(0.250, 0.460, 0.450, 0.940)", function (t, e, n, i) {
                    return -n * (t /= i) * (t - 2) + e
                }],
                "ease-in-out-quad": ["cubic-bezier(0.455, 0.030, 0.515, 0.955)", function (t, e, n, i) {
                    return (t /= i / 2) < 1 ? n / 2 * t * t + e : -n / 2 * (--t * (t - 2) - 1) + e
                }],
                "ease-in-cubic": ["cubic-bezier(0.550, 0.055, 0.675, 0.190)", function (t, e, n, i) {
                    return n * (t /= i) * t * t + e
                }],
                "ease-out-cubic": ["cubic-bezier(0.215, 0.610, 0.355, 1)", function (t, e, n, i) {
                    return n * ((t = t / i - 1) * t * t + 1) + e
                }],
                "ease-in-out-cubic": ["cubic-bezier(0.645, 0.045, 0.355, 1)", function (t, e, n, i) {
                    return (t /= i / 2) < 1 ? n / 2 * t * t * t + e : n / 2 * ((t -= 2) * t * t + 2) + e
                }],
                "ease-in-quart": ["cubic-bezier(0.895, 0.030, 0.685, 0.220)", function (t, e, n, i) {
                    return n * (t /= i) * t * t * t + e
                }],
                "ease-out-quart": ["cubic-bezier(0.165, 0.840, 0.440, 1)", function (t, e, n, i) {
                    return -n * ((t = t / i - 1) * t * t * t - 1) + e
                }],
                "ease-in-out-quart": ["cubic-bezier(0.770, 0, 0.175, 1)", function (t, e, n, i) {
                    return (t /= i / 2) < 1 ? n / 2 * t * t * t * t + e : -n / 2 * ((t -= 2) * t * t * t - 2) + e
                }],
                "ease-in-quint": ["cubic-bezier(0.755, 0.050, 0.855, 0.060)", function (t, e, n, i) {
                    return n * (t /= i) * t * t * t * t + e
                }],
                "ease-out-quint": ["cubic-bezier(0.230, 1, 0.320, 1)", function (t, e, n, i) {
                    return n * ((t = t / i - 1) * t * t * t * t + 1) + e
                }],
                "ease-in-out-quint": ["cubic-bezier(0.860, 0, 0.070, 1)", function (t, e, n, i) {
                    return (t /= i / 2) < 1 ? n / 2 * t * t * t * t * t + e : n / 2 * ((t -= 2) * t * t * t * t + 2) + e
                }],
                "ease-in-sine": ["cubic-bezier(0.470, 0, 0.745, 0.715)", function (t, e, n, i) {
                    return -n * Math.cos(t / i * (Math.PI / 2)) + n + e
                }],
                "ease-out-sine": ["cubic-bezier(0.390, 0.575, 0.565, 1)", function (t, e, n, i) {
                    return n * Math.sin(t / i * (Math.PI / 2)) + e
                }],
                "ease-in-out-sine": ["cubic-bezier(0.445, 0.050, 0.550, 0.950)", function (t, e, n, i) {
                    return -n / 2 * (Math.cos(Math.PI * t / i) - 1) + e
                }],
                "ease-in-expo": ["cubic-bezier(0.950, 0.050, 0.795, 0.035)", function (t, e, n, i) {
                    return 0 === t ? e : n * Math.pow(2, 10 * (t / i - 1)) + e
                }],
                "ease-out-expo": ["cubic-bezier(0.190, 1, 0.220, 1)", function (t, e, n, i) {
                    return t === i ? e + n : n * (1 - Math.pow(2, -10 * t / i)) + e
                }],
                "ease-in-out-expo": ["cubic-bezier(1, 0, 0, 1)", function (t, e, n, i) {
                    return 0 === t ? e : t === i ? e + n : (t /= i / 2) < 1 ? n / 2 * Math.pow(2, 10 * (t - 1)) + e : n / 2 * (2 - Math.pow(2, -10 * --t)) + e
                }],
                "ease-in-circ": ["cubic-bezier(0.600, 0.040, 0.980, 0.335)", function (t, e, n, i) {
                    return -n * (Math.sqrt(1 - (t /= i) * t) - 1) + e
                }],
                "ease-out-circ": ["cubic-bezier(0.075, 0.820, 0.165, 1)", function (t, e, n, i) {
                    return n * Math.sqrt(1 - (t = t / i - 1) * t) + e
                }],
                "ease-in-out-circ": ["cubic-bezier(0.785, 0.135, 0.150, 0.860)", function (t, e, n, i) {
                    return (t /= i / 2) < 1 ? -n / 2 * (Math.sqrt(1 - t * t) - 1) + e : n / 2 * (Math.sqrt(1 - (t -= 2) * t) + 1) + e
                }],
                "ease-in-back": ["cubic-bezier(0.600, -0.280, 0.735, 0.045)", function (t, e, n, i, r) {
                    return void 0 === r && (r = 1.70158), n * (t /= i) * t * ((r + 1) * t - r) + e
                }],
                "ease-out-back": ["cubic-bezier(0.175, 0.885, 0.320, 1.275)", function (t, e, n, i, r) {
                    return void 0 === r && (r = 1.70158), n * ((t = t / i - 1) * t * ((r + 1) * t + r) + 1) + e
                }],
                "ease-in-out-back": ["cubic-bezier(0.680, -0.550, 0.265, 1.550)", function (t, e, n, i, r) {
                    return void 0 === r && (r = 1.70158), (t /= i / 2) < 1 ? n / 2 * t * t * ((1 + (r *= 1.525)) * t - r) + e : n / 2 * ((t -= 2) * t * ((1 + (r *= 1.525)) * t + r) + 2) + e
                }]
            },
            f = {
                "ease-in-back": "cubic-bezier(0.600, 0, 0.735, 0.045)",
                "ease-out-back": "cubic-bezier(0.175, 0.885, 0.320, 1)",
                "ease-in-out-back": "cubic-bezier(0.680, 0, 0.265, 1)"
            },
            d = document,
            h = window,
            p = "bkwld-tram",
            v = /[\-\.0-9]/g,
            m = /[A-Z]/,
            g = /^(rgb|#)/,
            w = /(em|cm|mm|in|pt|pc|px)$/,
            b = /(em|cm|mm|in|pt|pc|px|%)$/,
            y = /(deg|rad|turn)$/,
            x = /(all|none) 0s ease 0s/,
            k = /^(width|height)$/,
            _ = " ",
            T = d.createElement("a"),
            z = ["Webkit", "Moz", "O", "ms"],
            O = ["-webkit-", "-moz-", "-o-", "-ms-"],
            E = function (t) {
                if (t in T.style) return {
                    dom: t,
                    css: t
                };
                var e, n, i = "",
                    r = t.split("-");
                for (e = 0; e < r.length; e++) i += r[e].charAt(0).toUpperCase() + r[e].slice(1);
                for (e = 0; e < z.length; e++)
                    if ((n = z[e] + i) in T.style) return {
                        dom: n,
                        css: O[e] + t
                    }
            },
            A = e.support = {
                bind: Function.prototype.bind,
                transform: E("transform"),
                transition: E("transition"),
                backface: E("backface-visibility"),
                timing: E("transition-timing-function")
            };
        if (A.transition) {
            var j = A.timing.dom;
            if (T.style[j] = l["ease-in-back"][0], !T.style[j])
                for (var C in f) l[C][0] = f[C]
        }
        var M = e.frame = function () {
            var t = h.requestAnimationFrame || h.webkitRequestAnimationFrame || h.mozRequestAnimationFrame || h.oRequestAnimationFrame || h.msRequestAnimationFrame;
            return t && A.bind ? t.bind(h) : function (t) {
                h.setTimeout(t, 16)
            }
        }(),
            q = e.now = function () {
                var t = h.performance,
                    e = t && (t.now || t.webkitNow || t.msNow || t.mozNow);
                return e && A.bind ? e.bind(t) : Date.now || function () {
                    return +new Date
                }
            }(),
            I = c(function (e) {
                function r(t, e) {
                    var n = function (t) {
                        for (var e = -1, n = t ? t.length : 0, i = []; ++e < n;) {
                            var r = t[e];
                            r && i.push(r)
                        }
                        return i
                    }(("" + t).split(_)),
                        i = n[0];
                    e = e || {};
                    var r = U[i];
                    if (!r) return u("Unsupported property: " + i);
                    if (!e.weak || !this.props[i]) {
                        var o = r[0],
                            a = this.props[i];
                        return a || (a = this.props[i] = new o.Bare), a.init(this.$el, n, r, e), a
                    }
                }

                function o(t, e, i) {
                    if (t) {
                        var o = void 0 === t ? "undefined" : n(t);
                        if (e || (this.timer && this.timer.destroy(), this.queue = [], this.active = !1), "number" == o && e) return this.timer = new B({
                            duration: t,
                            context: this,
                            complete: a
                        }), void (this.active = !0);
                        if ("string" == o && e) {
                            switch (t) {
                                case "hide":
                                    l.call(this);
                                    break;
                                case "stop":
                                    c.call(this);
                                    break;
                                case "redraw":
                                    f.call(this);
                                    break;
                                default:
                                    r.call(this, t, i && i[1])
                            }
                            return a.call(this)
                        }
                        if ("function" == o) return void t.call(this, this);
                        if ("object" == o) {
                            var u = 0;
                            h.call(this, t, function (t, e) {
                                t.span > u && (u = t.span), t.stop(), t.animate(e)
                            }, function (t) {
                                "wait" in t && (u = s(t.wait, 0))
                            }), d.call(this), u > 0 && (this.timer = new B({
                                duration: u,
                                context: this
                            }), this.active = !0, e && (this.timer.complete = a));
                            var p = this,
                                v = !1,
                                m = {};
                            M(function () {
                                h.call(p, t, function (t) {
                                    t.active && (v = !0, m[t.name] = t.nextStyle)
                                }), v && p.$el.css(m)
                            })
                        }
                    }
                }

                function a() {
                    if (this.timer && this.timer.destroy(), this.active = !1, this.queue.length) {
                        var t = this.queue.shift();
                        o.call(this, t.options, !0, t.args)
                    }
                }

                function c(t) {
                    this.timer && this.timer.destroy(), this.queue = [], this.active = !1;
                    var e;
                    "string" == typeof t ? (e = {}, e[t] = 1) : e = "object" == (void 0 === t ? "undefined" : n(t)) && null != t ? t : this.props, h.call(this, e, v), d.call(this)
                }

                function l() {
                    c.call(this), this.el.style.display = "none"
                }

                function f() {
                    this.el.offsetHeight
                }

                function d() {
                    var t, e, n = [];
                    this.upstream && n.push(this.upstream);
                    for (t in this.props) (e = this.props[t]).active && n.push(e.string);
                    n = n.join(","), this.style !== n && (this.style = n, this.el.style[A.transition.dom] = n)
                }

                function h(t, e, n) {
                    var o, a, s, u, c = e !== v,
                        l = {};
                    for (o in t) s = t[o], o in Z ? (l.transform || (l.transform = {}), l.transform[o] = s) : (m.test(o) && (o = i(o)), o in U ? l[o] = s : (u || (u = {}), u[o] = s));
                    for (o in l) {
                        if (s = l[o], !(a = this.props[o])) {
                            if (!c) continue;
                            a = r.call(this, o)
                        }
                        e.call(this, a, s)
                    }
                    n && u && n.call(this, u)
                }

                function v(t) {
                    t.stop()
                }

                function g(t, e) {
                    t.set(e)
                }

                function w(t) {
                    this.$el.css(t)
                }

                function b(t, n) {
                    e[t] = function () {
                        return this.children ? function (t, e) {
                            var n, i = this.children.length;
                            for (n = 0; i > n; n++) t.apply(this.children[n], e);
                            return this
                        }.call(this, n, arguments) : (this.el && n.apply(this, arguments), this)
                    }
                }
                e.init = function (e) {
                    if (this.$el = t(e), this.el = this.$el[0], this.props = {}, this.queue = [], this.style = "", this.active = !1, H.keepInherited && !H.fallback) {
                        var n = X(this.el, "transition");
                        n && !x.test(n) && (this.upstream = n)
                    }
                    A.backface && H.hideBackface && P(this.el, A.backface.css, "hidden")
                }, b("add", r), b("start", o), b("wait", function (t) {
                    t = s(t, 0), this.active ? this.queue.push({
                        options: t
                    }) : (this.timer = new B({
                        duration: t,
                        context: this,
                        complete: a
                    }), this.active = !0)
                }), b("then", function (t) {
                    return this.active ? (this.queue.push({
                        options: t,
                        args: arguments
                    }), void (this.timer.complete = a)) : u("No active transition timer. Use start() or wait() before then().")
                }), b("next", a), b("stop", c), b("set", function (t) {
                    c.call(this, t), h.call(this, t, g, w)
                }), b("show", function (t) {
                    "string" != typeof t && (t = "block"), this.el.style.display = t
                }), b("hide", l), b("redraw", f), b("destroy", function () {
                    c.call(this), t.removeData(this.el, p), this.$el = this.el = null
                })
            }),
            $ = c(I, function (e) {
                function n(e, n) {
                    var i = t.data(e, p) || t.data(e, p, new I.Bare);
                    return i.el || i.init(e), n ? i.start(n) : i
                }
                e.init = function (e, i) {
                    var r = t(e);
                    if (!r.length) return this;
                    if (1 === r.length) return n(r[0], i);
                    var o = [];
                    return r.each(function (t, e) {
                        o.push(n(e, i))
                    }), this.children = o, this
                }
            }),
            S = c(function (t) {
                function e() {
                    var t = this.get();
                    this.update("auto");
                    var e = this.get();
                    return this.update(t), e
                }
                var i = 500,
                    r = "ease",
                    a = 0;
                t.init = function (t, e, n, o) {
                    this.$el = t, this.el = t[0];
                    var u = e[0];
                    n[2] && (u = n[2]), W[u] && (u = W[u]), this.name = u, this.type = n[1], this.duration = s(e[1], this.duration, i), this.ease = function (t, e, n) {
                        return void 0 !== e && (n = e), t in l ? t : n
                    }(e[2], this.ease, r), this.delay = s(e[3], this.delay, a), this.span = this.duration + this.delay, this.active = !1, this.nextStyle = null, this.auto = k.test(this.name), this.unit = o.unit || this.unit || H.defaultUnit, this.angle = o.angle || this.angle || H.defaultAngle, H.fallback || o.fallback ? this.animate = this.fallback : (this.animate = this.transition, this.string = this.name + _ + this.duration + "ms" + ("ease" != this.ease ? _ + l[this.ease][0] : "") + (this.delay ? _ + this.delay + "ms" : ""))
                }, t.set = function (t) {
                    t = this.convert(t, this.type), this.update(t), this.redraw()
                }, t.transition = function (t) {
                    this.active = !0, t = this.convert(t, this.type), this.auto && ("auto" == this.el.style[this.name] && (this.update(this.get()), this.redraw()), "auto" == t && (t = e.call(this))), this.nextStyle = t
                }, t.fallback = function (t) {
                    var n = this.el.style[this.name] || this.convert(this.get(), this.type);
                    t = this.convert(t, this.type), this.auto && ("auto" == n && (n = this.convert(this.get(), this.type)), "auto" == t && (t = e.call(this))), this.tween = new N({
                        from: n,
                        to: t,
                        duration: this.duration,
                        delay: this.delay,
                        ease: this.ease,
                        update: this.update,
                        context: this
                    })
                }, t.get = function () {
                    return X(this.el, this.name)
                }, t.update = function (t) {
                    P(this.el, this.name, t)
                }, t.stop = function () {
                    (this.active || this.nextStyle) && (this.active = !1, this.nextStyle = null, P(this.el, this.name, this.get()));
                    var t = this.tween;
                    t && t.context && t.destroy()
                }, t.convert = function (t, e) {
                    if ("auto" == t && this.auto) return t;
                    var i, r = "number" == typeof t,
                        a = "string" == typeof t;
                    switch (e) {
                        case "number":
                            if (r) return t;
                            if (a && "" === t.replace(v, "")) return +t;
                            i = "number(unitless)";
                            break;
                        case g:
                            if (a) {
                                if ("" === t && this.original) return this.original;
                                if (e.test(t)) return "#" == t.charAt(0) && 7 == t.length ? t : function (t) {
                                    var e = /rgba?\((\d+),\s*(\d+),\s*(\d+)/.exec(t);
                                    return (e ? o(e[1], e[2], e[3]) : t).replace(/#(\w)(\w)(\w)$/, "#$1$1$2$2$3$3")
                                }(t)
                            }
                            i = "hex or rgb string";
                            break;
                        case w:
                            if (r) return t + this.unit;
                            if (a && e.test(t)) return t;
                            i = "number(px) or string(unit)";
                            break;
                        case b:
                            if (r) return t + this.unit;
                            if (a && e.test(t)) return t;
                            i = "number(px) or string(unit or %)";
                            break;
                        case y:
                            if (r) return t + this.angle;
                            if (a && e.test(t)) return t;
                            i = "number(deg) or string(angle)";
                            break;
                        case "unitless":
                            if (r) return t;
                            if (a && b.test(t)) return t;
                            i = "number(unitless) or string(unit or %)"
                    }
                    return function (t, e) {
                        u("Type warning: Expected: [" + t + "] Got: [" + (void 0 === e ? "undefined" : n(e)) + "] " + e)
                    }(i, t), t
                }, t.redraw = function () {
                    this.el.offsetHeight
                }
            }),
            D = c(S, function (t, e) {
                t.init = function () {
                    e.init.apply(this, arguments), this.original || (this.original = this.convert(this.get(), g))
                }
            }),
            R = c(S, function (t, e) {
                t.init = function () {
                    e.init.apply(this, arguments), this.animate = this.fallback
                }, t.get = function () {
                    return this.$el[this.name]()
                }, t.update = function (t) {
                    this.$el[this.name](t)
                }
            }),
            L = c(S, function (t, e) {
                function n(t, e) {
                    var n, i, r, o, a;
                    for (n in t) r = (o = Z[n])[0], i = o[1] || n, a = this.convert(t[n], r), e.call(this, i, a, r)
                }
                t.init = function () {
                    e.init.apply(this, arguments), this.current || (this.current = {}, Z.perspective && H.perspective && (this.current.perspective = H.perspective, P(this.el, this.name, this.style(this.current)), this.redraw()))
                }, t.set = function (t) {
                    n.call(this, t, function (t, e) {
                        this.current[t] = e
                    }), P(this.el, this.name, this.style(this.current)), this.redraw()
                }, t.transition = function (t) {
                    var e = this.values(t);
                    this.tween = new F({
                        current: this.current,
                        values: e,
                        duration: this.duration,
                        delay: this.delay,
                        ease: this.ease
                    });
                    var n, i = {};
                    for (n in this.current) i[n] = n in e ? e[n] : this.current[n];
                    this.active = !0, this.nextStyle = this.style(i)
                }, t.fallback = function (t) {
                    var e = this.values(t);
                    this.tween = new F({
                        current: this.current,
                        values: e,
                        duration: this.duration,
                        delay: this.delay,
                        ease: this.ease,
                        update: this.update,
                        context: this
                    })
                }, t.update = function () {
                    P(this.el, this.name, this.style(this.current))
                }, t.style = function (t) {
                    var e, n = "";
                    for (e in t) n += e + "(" + t[e] + ") ";
                    return n
                }, t.values = function (t) {
                    var e, i = {};
                    return n.call(this, t, function (t, n, r) {
                        i[t] = n, void 0 === this.current[t] && (e = 0, ~t.indexOf("scale") && (e = 1), this.current[t] = this.convert(e, r))
                    }), i
                }
            }),
            N = c(function (e) {
                function n() {
                    var t, e, i, r = s.length;
                    if (r)
                        for (M(n), e = q(), t = r; t--;)(i = s[t]) && i.render(e)
                }
                var i = {
                    ease: l.ease[1],
                    from: 0,
                    to: 1
                };
                e.init = function (t) {
                    this.duration = t.duration || 0, this.delay = t.delay || 0;
                    var e = t.ease || i.ease;
                    l[e] && (e = l[e][1]), "function" != typeof e && (e = i.ease), this.ease = e, this.update = t.update || a, this.complete = t.complete || a, this.context = t.context || this, this.name = t.name;
                    var n = t.from,
                        r = t.to;
                    void 0 === n && (n = i.from), void 0 === r && (r = i.to), this.unit = t.unit || "", "number" == typeof n && "number" == typeof r ? (this.begin = n, this.change = r - n) : this.format(r, n), this.value = this.begin + this.unit, this.start = q(), !1 !== t.autoplay && this.play()
                }, e.play = function () {
                    this.active || (this.start || (this.start = q()), this.active = !0, function (t) {
                        1 === s.push(t) && M(n)
                    }(this))
                }, e.stop = function () {
                    this.active && (this.active = !1, function (e) {
                        var n, i = t.inArray(e, s);
                        i >= 0 && (n = s.slice(i + 1), s.length = i, n.length && (s = s.concat(n)))
                    }(this))
                }, e.render = function (t) {
                    var e, n = t - this.start;
                    if (this.delay) {
                        if (n <= this.delay) return;
                        n -= this.delay
                    }
                    if (n < this.duration) {
                        var i = this.ease(n, 0, 1, this.duration);
                        return e = this.startRGB ? function (t, e, n) {
                            return o(t[0] + n * (e[0] - t[0]), t[1] + n * (e[1] - t[1]), t[2] + n * (e[2] - t[2]))
                        }(this.startRGB, this.endRGB, i) : function (t) {
                            return Math.round(t * c) / c
                        }(this.begin + i * this.change), this.value = e + this.unit, void this.update.call(this.context, this.value)
                    }
                    e = this.endHex || this.begin + this.change, this.value = e + this.unit, this.update.call(this.context, this.value), this.complete.call(this.context), this.destroy()
                }, e.format = function (t, e) {
                    if (e += "", "#" == (t += "").charAt(0)) return this.startRGB = r(e), this.endRGB = r(t), this.endHex = t, this.begin = 0, void (this.change = 1);
                    if (!this.unit) {
                        var n = e.replace(v, "");
                        n !== t.replace(v, "") && function (t, e, n) {
                            u("Units do not match [" + t + "]: " + e + ", " + n)
                        }("tween", e, t), this.unit = n
                    }
                    e = parseFloat(e), t = parseFloat(t), this.begin = this.value = e, this.change = t - e
                }, e.destroy = function () {
                    this.stop(), this.context = null, this.ease = this.update = this.complete = a
                };
                var s = [],
                    c = 1e3
            }),
            B = c(N, function (t) {
                t.init = function (t) {
                    this.duration = t.duration || 0, this.complete = t.complete || a, this.context = t.context, this.play()
                }, t.render = function (t) {
                    t - this.start < this.duration || (this.complete.call(this.context), this.destroy())
                }
            }),
            F = c(N, function (t, e) {
                t.init = function (t) {
                    this.context = t.context, this.update = t.update, this.tweens = [], this.current = t.current;
                    var e, n;
                    for (e in t.values) n = t.values[e], this.current[e] !== n && this.tweens.push(new N({
                        name: e,
                        from: this.current[e],
                        to: n,
                        duration: t.duration,
                        delay: t.delay,
                        ease: t.ease,
                        autoplay: !1
                    }));
                    this.play()
                }, t.render = function (t) {
                    var e, n, i = !1;
                    for (e = this.tweens.length; e--;)(n = this.tweens[e]).context && (n.render(t), this.current[n.name] = n.value, i = !0);
                    return i ? void (this.update && this.update.call(this.context)) : this.destroy()
                }, t.destroy = function () {
                    if (e.destroy.call(this), this.tweens) {
                        var t;
                        for (t = this.tweens.length; t--;) this.tweens[t].destroy();
                        this.tweens = null, this.current = null
                    }
                }
            }),
            H = e.config = {
                debug: !1,
                defaultUnit: "px",
                defaultAngle: "deg",
                keepInherited: !1,
                hideBackface: !1,
                perspective: "",
                fallback: !A.transition,
                agentTests: []
            };
        e.fallback = function (t) {
            if (!A.transition) return H.fallback = !0;
            H.agentTests.push("(" + t + ")");
            var e = new RegExp(H.agentTests.join("|"), "i");
            H.fallback = e.test(navigator.userAgent)
        }, e.fallback("6.0.[2-5] Safari"), e.tween = function (t) {
            return new N(t)
        }, e.delay = function (t, e, n) {
            return new B({
                complete: e,
                duration: t,
                context: n
            })
        }, t.fn.tram = function (t) {
            return e.call(null, this, t)
        };
        var P = t.style,
            X = t.css,
            W = {
                transform: A.transform && A.transform.css
            },
            U = {
                color: [D, g],
                background: [D, g, "background-color"],
                "outline-color": [D, g],
                "border-color": [D, g],
                "border-top-color": [D, g],
                "border-right-color": [D, g],
                "border-bottom-color": [D, g],
                "border-left-color": [D, g],
                "border-width": [S, w],
                "border-top-width": [S, w],
                "border-right-width": [S, w],
                "border-bottom-width": [S, w],
                "border-left-width": [S, w],
                "border-spacing": [S, w],
                "letter-spacing": [S, w],
                margin: [S, w],
                "margin-top": [S, w],
                "margin-right": [S, w],
                "margin-bottom": [S, w],
                "margin-left": [S, w],
                padding: [S, w],
                "padding-top": [S, w],
                "padding-right": [S, w],
                "padding-bottom": [S, w],
                "padding-left": [S, w],
                "outline-width": [S, w],
                opacity: [S, "number"],
                top: [S, b],
                right: [S, b],
                bottom: [S, b],
                left: [S, b],
                "font-size": [S, b],
                "text-indent": [S, b],
                "word-spacing": [S, b],
                width: [S, b],
                "min-width": [S, b],
                "max-width": [S, b],
                height: [S, b],
                "min-height": [S, b],
                "max-height": [S, b],
                "line-height": [S, "unitless"],
                "scroll-top": [R, "number", "scrollTop"],
                "scroll-left": [R, "number", "scrollLeft"]
            },
            Z = {};
        A.transform && (U.transform = [L], Z = {
            x: [b, "translateX"],
            y: [b, "translateY"],
            rotate: [y],
            rotateX: [y],
            rotateY: [y],
            scale: ["number"],
            scaleX: ["number"],
            scaleY: ["number"],
            skew: [y],
            skewX: [y],
            skewY: [y]
        }), A.transform && A.backface && (Z.z = [b, "translateZ"], Z.rotateZ = [y], Z.scaleZ = ["number"], Z.perspective = [w]);
        var Y = /ms/,
            G = /s|\./;
        return t.tram = e
    }(window.jQuery)
}, function (t, e, n) {
    "use strict";
    var i = window.jQuery,
        r = {},
        o = [],
        a = {
            reset: function (t, e) {
                e.__wf_intro = null
            },
            intro: function (t, e) {
                e.__wf_intro || (e.__wf_intro = !0, i(e).triggerHandler(r.types.INTRO))
            },
            outro: function (t, e) {
                e.__wf_intro && (e.__wf_intro = null, i(e).triggerHandler(r.types.OUTRO))
            }
        };
    r.triggers = {}, r.types = {
        INTRO: "w-ix-intro.w-ix",
        OUTRO: "w-ix-outro.w-ix"
    }, r.init = function () {
        for (var t = o.length, e = 0; e < t; e++) {
            var n = o[e];
            n[0](0, n[1])
        }
        o = [], i.extend(r.triggers, a)
    }, r.async = function () {
        for (var t in a) {
            var e = a[t];
            a.hasOwnProperty(t) && (r.triggers[t] = function (t, n) {
                o.push([e, n])
            })
        }
    }, r.async(), t.exports = r
}, function (t, e, n) {
    n(5), n(8), n(9), n(10), n(11), n(13), n(14), n(15), n(16), n(17), n(18), t.exports = n(19)
}, function (t, e, n) {
    var i = n(0),
        r = n(7);
    i.define("backgroundVideo", t.exports = function (t) {
        return {
            ready: function () {
                if (!i.env()) {
                    var e = t(document).find(".w-background-video").not(".w-background-video-atom");
                    0 !== e.length && e.each(function (e, n) {
                        var i = function (e) {
                            var n = t(e).data();
                            if (n.videoUrls) {
                                if (!r.isMobile()) {
                                    var i = n.videoUrls.split(",").map(function (e) {
                                        return t("<source />").attr({
                                            src: e,
                                            "data-wf-ignore": ""
                                        })
                                    }),
                                        o = t("<video />").attr({
                                            autoplay: n.autoplay,
                                            loop: n.loop
                                        }).css("background-image", "url(" + n.posterUrl + ")");
                                    return o.append(i), o
                                }
                                if (n.posterUrl) return t('<div class="w-background-video-poster">').css({
                                    backgroundImage: "url(" + n.posterUrl + ")",
                                    backgroundSize: "cover",
                                    backgroundPosition: "50% 50%",
                                    position: "absolute",
                                    zIndex: -100,
                                    width: "100%",
                                    height: "100%",
                                    top: 0,
                                    left: 0
                                })
                            }
                        }(n);
                        i && t(n).prepend(i)
                    })
                }
            }
        }
    })
}, function (t, e, n) {
    var i = window.$,
        r = n(2) && i.tram;
    /*!
     * Webflow._ (aka) Underscore.js 1.6.0 (custom build)
     * _.each
     * _.map
     * _.find
     * _.filter
     * _.any
     * _.contains
     * _.delay
     * _.defer
     * _.throttle (webflow)
     * _.debounce
     * _.keys
     * _.has
     * _.now
     *
     * http://underscorejs.org
     * (c) 2009-2013 Jeremy Ashkenas, DocumentCloud and Investigative Reporters & Editors
     * Underscore may be freely distributed under the MIT license.
     * @license MIT
     */
    t.exports = function () {
        var t = {};
        t.VERSION = "1.6.0-Webflow";
        var e = {},
            n = Array.prototype,
            i = Object.prototype,
            o = Function.prototype,
            a = (n.push, n.slice),
            s = (n.concat, i.toString, i.hasOwnProperty),
            u = n.forEach,
            c = n.map,
            l = (n.reduce, n.reduceRight, n.filter),
            f = (n.every, n.some),
            d = n.indexOf,
            h = (n.lastIndexOf, Array.isArray, Object.keys),
            p = (o.bind, t.each = t.forEach = function (n, i, r) {
                if (null == n) return n;
                if (u && n.forEach === u) n.forEach(i, r);
                else if (n.length === +n.length) {
                    for (var o = 0, a = n.length; o < a; o++)
                        if (i.call(r, n[o], o, n) === e) return
                } else {
                    var s = t.keys(n);
                    for (o = 0, a = s.length; o < a; o++)
                        if (i.call(r, n[s[o]], s[o], n) === e) return
                }
                return n
            });
        t.map = t.collect = function (t, e, n) {
            var i = [];
            return null == t ? i : c && t.map === c ? t.map(e, n) : (p(t, function (t, r, o) {
                i.push(e.call(n, t, r, o))
            }), i)
        }, t.find = t.detect = function (t, e, n) {
            var i;
            return v(t, function (t, r, o) {
                if (e.call(n, t, r, o)) return i = t, !0
            }), i
        }, t.filter = t.select = function (t, e, n) {
            var i = [];
            return null == t ? i : l && t.filter === l ? t.filter(e, n) : (p(t, function (t, r, o) {
                e.call(n, t, r, o) && i.push(t)
            }), i)
        };
        var v = t.some = t.any = function (n, i, r) {
            i || (i = t.identity);
            var o = !1;
            return null == n ? o : f && n.some === f ? n.some(i, r) : (p(n, function (t, n, a) {
                if (o || (o = i.call(r, t, n, a))) return e
            }), !!o)
        };
        t.contains = t.include = function (t, e) {
            return null != t && (d && t.indexOf === d ? -1 != t.indexOf(e) : v(t, function (t) {
                return t === e
            }))
        }, t.delay = function (t, e) {
            var n = a.call(arguments, 2);
            return setTimeout(function () {
                return t.apply(null, n)
            }, e)
        }, t.defer = function (e) {
            return t.delay.apply(t, [e, 1].concat(a.call(arguments, 1)))
        }, t.throttle = function (t) {
            var e, n, i;
            return function () {
                e || (e = !0, n = arguments, i = this, r.frame(function () {
                    e = !1, t.apply(i, n)
                }))
            }
        }, t.debounce = function (e, n, i) {
            var r, o, a, s, u, c = function c() {
                var l = t.now() - s;
                l < n ? r = setTimeout(c, n - l) : (r = null, i || (u = e.apply(a, o), a = o = null))
            };
            return function () {
                a = this, o = arguments, s = t.now();
                var l = i && !r;
                return r || (r = setTimeout(c, n)), l && (u = e.apply(a, o), a = o = null), u
            }
        }, t.defaults = function (e) {
            if (!t.isObject(e)) return e;
            for (var n = 1, i = arguments.length; n < i; n++) {
                var r = arguments[n];
                for (var o in r) void 0 === e[o] && (e[o] = r[o])
            }
            return e
        }, t.keys = function (e) {
            if (!t.isObject(e)) return [];
            if (h) return h(e);
            var n = [];
            for (var i in e) t.has(e, i) && n.push(i);
            return n
        }, t.has = function (t, e) {
            return s.call(t, e)
        }, t.isObject = function (t) {
            return t === Object(t)
        }, t.now = Date.now || function () {
            return (new Date).getTime()
        }, t.templateSettings = {
            evaluate: /<%([\s\S]+?)%>/g,
            interpolate: /<%=([\s\S]+?)%>/g,
            escape: /<%-([\s\S]+?)%>/g
        };
        var m = /(.)^/,
            g = {
                "'": "'",
                "\\": "\\",
                "\r": "r",
                "\n": "n",
                "\u2028": "u2028",
                "\u2029": "u2029"
            },
            w = /\\|'|\r|\n|\u2028|\u2029/g,
            b = function (t) {
                return "\\" + g[t]
            };
        return t.template = function (e, n, i) {
            !n && i && (n = i), n = t.defaults({}, n, t.templateSettings);
            var r = RegExp([(n.escape || m).source, (n.interpolate || m).source, (n.evaluate || m).source].join("|") + "|$", "g"),
                o = 0,
                a = "__p+='";
            e.replace(r, function (t, n, i, r, s) {
                return a += e.slice(o, s).replace(w, b), o = s + t.length, n ? a += "'+\n((__t=(" + n + "))==null?'':_.escape(__t))+\n'" : i ? a += "'+\n((__t=(" + i + "))==null?'':__t)+\n'" : r && (a += "';\n" + r + "\n__p+='"), t
            }), a += "';\n", n.variable || (a = "with(obj||{}){\n" + a + "}\n"), a = "var __t,__p='',__j=Array.prototype.join,print=function(){__p+=__j.call(arguments,'');};\n" + a + "return __p;\n";
            try {
                var s = new Function(n.variable || "obj", "_", a)
            } catch (t) {
                throw t.source = a, t
            }
            var u = function (e) {
                return s.call(this, e, t)
            },
                c = n.variable || "obj";
            return u.source = "function(" + c + "){\n" + a + "}", u
        }, t
    }()
}, function (t, e) {
    e.isMobile = function () {
        var t = navigator.userAgent || navigator.vendor || window.opera;
        return /(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino/i.test(t) || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(t.substr(0, 4))
    }
}, function (t, e, n) {
    var i = n(0);
    i.define("brand", t.exports = function (t) {
        function e() {
            var t = a.children(s),
                e = t.length && t.get(0) === n,
                r = i.env("editor");
            e ? r && t.remove() : (t.length && t.remove(), r || a.append(n))
        }
        var n, r = {},
            o = t("html"),
            a = t("body"),
            s = ".w-webflow-badge",
            u = window.location,
            c = /PhantomJS/i.test(navigator.userAgent);
        return r.ready = function () {
            var i = o.attr("data-wf-status"),
                r = o.attr("data-wf-domain") || "";
            /\.webflow\.io$/i.test(r) && u.hostname !== r && (i = !0), i && !c && (n = n || function () {
                var e = t('<a class="w-webflow-badge"></a>').attr("href", "https://webflow.com?utm_campaign=brandjs"),
                    n = t("<img>").attr("src", "https://d1otoma47x30pg.cloudfront.net/img/webflow-badge-icon.60efbf6ec9.svg").css({
                        marginRight: "8px",
                        width: "16px"
                    }),
                    i = t("<img>").attr("src", "https://d1otoma47x30pg.cloudfront.net/img/webflow-badge-text.6faa6a38cd.svg");
                return e.append(n, i), e[0]
            }(), e(), setTimeout(e, 500))
        }, r
    })
}, function (t, e, n) {
    var i = n(0),
        r = n(1);
    i.define("dropdown", t.exports = function (t, e) {
        function n() {
            f = p && i.env("design"), (l = h.find(m)).each(o)
        }

        function o(n, r) {
            var o = t(r),
                l = t.data(r, m);
            l || (l = t.data(r, m, {
                open: !1,
                el: o,
                config: {}
            })), l.list = o.children(".w-dropdown-list"), l.toggle = o.children(".w-dropdown-toggle"), l.links = l.list.children(".w-dropdown-link"), l.outside = function (n) {
                n.outside && h.off("mouseup" + m, n.outside);
                return e.debounce(function (e) {
                    if (n.open) {
                        var r = t(e.target);
                        if (!r.closest(".w-dropdown-toggle").length) {
                            var o = -1 === t.inArray(n.el[0], r.parents(m)),
                                a = i.env("editor");
                            if (o) {
                                if (a) {
                                    var s = 1 === r.parents().length && 1 === r.parents("svg").length,
                                        u = r.parents(".w-editor-bem-EditorHoverControls").length;
                                    if (s || u) return
                                }
                                c(n)
                            }
                        }
                    }
                })
            }(l), l.complete = function (t) {
                return function () {
                    t.list.removeClass(g), t.toggle.removeClass(g), t.manageZ && t.el.css("z-index", "")
                }
            }(l), l.leave = function (t) {
                return function () {
                    t.hovering = !1, c(t)
                }
            }(l), l.moveOutside = function (n) {
                return e.debounce(function (e) {
                    if (n.open) {
                        var i = t(e.target),
                            r = -1 === t.inArray(n.el[0], i.parents(m));
                        if (r) {
                            var o = i.parents(".w-editor-bem-EditorHoverControls").length,
                                a = i.parents(".w-editor-bem-RTToolbar").length,
                                s = t(".w-editor-bem-EditorOverlay"),
                                u = s.find(".w-editor-edit-outline").length || s.find(".w-editor-bem-RTToolbar").length;
                            if (o || a || u) return;
                            n.hovering = !1, c(n)
                        }
                    }
                })
            }(l), o.off(m), l.toggle.off(m), a(l), l.nav && l.nav.off(m), l.nav = o.closest(".w-nav"), l.nav.on(w, s(l)), f ? o.on("setting" + m, s(l)) : (l.toggle.on("tap" + m, function (t) {
                return e.debounce(function () {
                    t.open ? c(t) : u(t)
                })
            }(l)), l.config.hover && l.toggle.on("mouseenter" + m, function (t) {
                return function () {
                    t.hovering = !0, u(t)
                }
            }(l)), o.on(w, s(l)), p && (l.hovering = !1, c(l)))
        }

        function a(t) {
            var e = Number(t.el.css("z-index"));
            t.manageZ = e === y || e === y + 1, t.config = {
                hover: Boolean(t.el.attr("data-hover")) && !v,
                delay: Number(t.el.attr("data-delay")) || 0
            }
        }

        function s(t) {
            return function (e, n) {
                return n = n || {}, "w-close" === e.type ? c(t) : "setting" === e.type ? (a(t), !0 === n.open && u(t), void (!1 === n.open && c(t, !0))) : void 0
            }
        }

        function u(e) {
            if (!e.open) {
                ! function (e) {
                    var n = e.el[0];
                    l.each(function (e, i) {
                        var r = t(i);
                        r.is(n) || r.has(n).length || r.triggerHandler(w)
                    })
                }(e), e.open = !0, e.list.addClass(g), e.toggle.addClass(g), b.intro(0, e.el[0]), i.redraw.up(), e.manageZ && e.el.css("z-index", y + 1);
                var n = i.env("editor");
                f || h.on("mouseup" + m, e.outside), e.hovering && !n && e.el.on("mouseleave" + m, e.leave), e.hovering && n && h.on("mousemove" + m, e.moveOutside), window.clearTimeout(e.delayId)
            }
        }

        function c(t, e) {
            if (t.open && (!t.config.hover || !t.hovering)) {
                t.open = !1;
                var n = t.config;
                if (b.outro(0, t.el[0]), h.off("mouseup" + m, t.outside), t.el.off("mouseleave" + m, t.leave), h.off("mousemove" + m, t.moveOutside), window.clearTimeout(t.delayId), !n.delay || e) return t.complete();
                t.delayId = window.setTimeout(t.complete, n.delay)
            }
        }
        var l, f, d = {},
            h = t(document),
            p = i.env(),
            v = i.env.touch,
            m = ".w-dropdown",
            g = "w--open",
            w = "w-close" + m,
            b = r.triggers,
            y = 900,
            x = !1;
        return d.ready = n, d.design = function () {
            x && h.find(m).each(function (e, n) {
                t(n).triggerHandler(w)
            }), x = !1, n()
        }, d.preview = function () {
            x = !0, n()
        }, d
    })
}, function (t, e, n) {
    var i = n(0);
    i.define("edit", t.exports = function (t, e, n) {
        function r() {
            u || /\?edit/.test(f.hash) && h()
        }

        function o(e) {
            e ? function (e, n) {
                t.ajax({
                    type: "GET",
                    url: e,
                    dataType: "script",
                    cache: !0
                }).then(n, a)
            }(function (t) {
                return t.indexOf("//") >= 0 ? t : s("https://editor-api.webflow.com" + t)
            }(e.scriptPath), function () {
                window.WebflowEditor(e)
            }) : console.error("Could not load editor data")
        }

        function a(t, e, n) {
            throw console.error("Could not load editor script: " + e), n
        }

        function s(t) {
            return t.replace(/([^:])\/\//g, "$1/")
        }
        if (n = n || {}, (i.env("test") || i.env("frame")) && !n.fixture) return {
            exit: 1
        };
        var u, c = t(window),
            l = t(document.documentElement),
            f = document.location,
            d = "hashchange",
            h = n.load || function () {
                u = !0, window.WebflowEditor = !0, c.off(d, r), t.ajax({
                    url: s("https://editor-api.webflow.com/api/editor/view"),
                    data: {
                        siteId: l.attr("data-wf-site")
                    },
                    xhrFields: {
                        withCredentials: !0
                    },
                    dataType: "json",
                    crossDomain: !0,
                    success: o
                })
            },
            p = !1;
        try {
            p = localStorage && localStorage.getItem && localStorage.getItem("WebflowEditor")
        } catch (t) { }
        return p ? h() : f.search ? (/[?&](edit)(?:[=&?]|$)/.test(f.search) || /\?edit$/.test(f.href)) && h() : c.on(d, r).triggerHandler(d), {}
    })
}, function (t, e, n) {
    var i = n(0);
    i.define("forms", t.exports = function (t, e) {
        function r(e, n) {
            var i = t(n),
                r = t.data(n, b);
            r || (r = t.data(n, b, {
                form: i
            })), o(r);
            var a = i.closest("div.w-form");
            r.done = a.find("> .w-form-done"), r.fail = a.find("> .w-form-fail");
            var s = r.action = i.attr("action");
            r.handler = null, r.redirect = i.attr("data-redirect"), T.test(s) ? r.handler = c : s || (p ? r.handler = u : z())
        }

        function o(t) {
            var e = t.btn = t.form.find(':input[type="submit"]');
            t.wait = t.btn.attr("data-wait") || null, t.success = !1, e.prop("disabled", !1), t.label && e.val(t.label)
        }

        function a(t) {
            var e = t.btn,
                n = t.wait;
            e.prop("disabled", !0), n && (t.label = e.val(), e.val(n))
        }

        function s(e, n) {
            var i = null;
            return n = n || {}, e.find(':input:not([type="submit"])').each(function (r, o) {
                var a = t(o),
                    s = a.attr("type"),
                    u = a.attr("data-name") || a.attr("name") || "Field " + (r + 1),
                    c = a.val();
                if ("checkbox" === s && (c = a.is(":checked")), "radio" === s) {
                    if (null === n[u] || "string" == typeof n[u]) return;
                    c = e.find('input[name="' + a.attr("name") + '"]:checked').val() || null
                }
                "string" == typeof c && (c = t.trim(c)), n[u] = c, i = i || function (t, e, n, i) {
                    var r = null;
                    "password" === e ? r = "Passwords cannot be submitted." : t.attr("required") && (i ? (y.test(n) || y.test(t.attr("type"))) && (x.test(i) || (r = "Please enter a valid email address for: " + n)) : r = "Please fill out the required field: " + n);
                    return r
                }(a, s, u, c)
            }), i
        }

        function u(e) {
            o(e);
            var n = e.form,
                r = {
                    name: n.attr("data-name") || n.attr("name") || "Untitled Form",
                    source: g.href,
                    test: i.env(),
                    fields: {},
                    dolphin: /pass[\s-_]?(word|code)|secret|login|credentials/i.test(n.html())
                };
            f(e);
            var u = s(n, r.fields);
            if (u) return k(u);
            if (a(e), p) {
                var c = "https://webflow.com/api/v1/form/" + p;
                w && c.indexOf("https://webflow.com") >= 0 && (c = c.replace("https://webflow.com", "http://formdata.webflow.com")), t.ajax({
                    url: c,
                    type: "POST",
                    data: r,
                    dataType: "json",
                    crossDomain: !0
                }).done(function () {
                    e.success = !0, l(e)
                }).fail(function () {
                    l(e)
                })
            } else l(e)
        }

        function c(n) {
            o(n);
            var i = n.form,
                r = {};
            if (!/^https/.test(g.href) || /^https/.test(n.action)) {
                f(n);
                var u = s(i, r);
                if (u) return k(u);
                a(n);
                var c;
                e.each(r, function (t, e) {
                    y.test(e) && (r.EMAIL = t), /^((full[ _-]?)?name)$/i.test(e) && (c = t), /^(first[ _-]?name)$/i.test(e) && (r.FNAME = t), /^(last[ _-]?name)$/i.test(e) && (r.LNAME = t)
                }), c && !r.FNAME && (c = c.split(" "), r.FNAME = c[0], r.LNAME = r.LNAME || c[1]);
                var d = n.action.replace("/post?", "/post-json?") + "&c=?",
                    h = d.indexOf("u=") + 2;
                h = d.substring(h, d.indexOf("&", h));
                var p = d.indexOf("id=") + 3;
                p = d.substring(p, d.indexOf("&", p)), r["b_" + h + "_" + p] = "", t.ajax({
                    url: d,
                    data: r,
                    dataType: "jsonp"
                }).done(function (t) {
                    n.success = "success" === t.result || /already/.test(t.msg), n.success || console.info("MailChimp error: " + t.msg), l(n)
                }).fail(function () {
                    l(n)
                })
            } else i.attr("method", "post")
        }

        function l(t) {
            var e = t.form,
                n = t.redirect,
                r = t.success;
            r && n ? i.location(n) : (t.done.toggle(r), t.fail.toggle(!r), e.toggle(!r), o(t))
        }

        function f(t) {
            t.evt && t.evt.preventDefault(), t.evt = null
        }
        var d = {};
        n(12);
        var h,
            p,
            v,
            m = t(document),
            g = window.location,
            w = window.XDomainRequest && !window.atob,
            b = ".w-form",
            y = /e(-)?mail/i,
            x = /^\S+@\S+$/,
            k = window.alert,
            _ = i.env(),
            T = /list-manage[1-9]?.com/i,
            //z = e.debounce(function () {k("Oops! This page has improperly configured forms. Please contact your website administrator to fix this issue.")}, 100);
            z = function() { return false };
        return d.ready = d.design = d.preview = function () {
            p = t("html").attr("data-wf-site"), (h = t(b + " form")).length && h.each(r), _ || v || (v = !0, m.on("submit", b + " form", function (e) {
                var n = t.data(this, b);
                n.handler && (n.evt = e, n.handler(n))
            }))
        }, d
    })
}, function (t, e) {
    /*!
     * jQuery-ajaxTransport-XDomainRequest - v1.0.3
     * 2014-12-16 WEBFLOW - Removed UMD wrapper
     * https://github.com/MoonScript/jQuery-ajaxTransport-XDomainRequest
     * Copyright (c) 2014 Jason Moon (@JSONMOON)
     * @license MIT (/blob/master/LICENSE.txt)
     */
    t.exports = function (t) {
        if (!t.support.cors && t.ajaxTransport && window.XDomainRequest) {
            var e = /^https?:\/\//i,
                n = /^get|post$/i,
                i = new RegExp("^" + location.protocol, "i");
            t.ajaxTransport("* text html xml json", function (r, o, a) {
                if (r.crossDomain && r.async && n.test(r.type) && e.test(r.url) && i.test(r.url)) {
                    var s = null;
                    return {
                        send: function (e, n) {
                            var i = "",
                                a = (o.dataType || "").toLowerCase();
                            s = new XDomainRequest, /^\d+$/.test(o.timeout) && (s.timeout = o.timeout), s.ontimeout = function () {
                                n(500, "timeout")
                            }, s.onload = function () {
                                var e = "Content-Length: " + s.responseText.length + "\r\nContent-Type: " + s.contentType,
                                    i = {
                                        code: 200,
                                        message: "success"
                                    },
                                    r = {
                                        text: s.responseText
                                    };
                                try {
                                    if ("html" === a || /text\/html/i.test(s.contentType)) r.html = s.responseText;
                                    else if ("json" === a || "text" !== a && /\/json/i.test(s.contentType)) try {
                                        r.json = t.parseJSON(s.responseText)
                                    } catch (t) {
                                        i.code = 500, i.message = "parseerror"
                                    } else if ("xml" === a || "text" !== a && /\/xml/i.test(s.contentType)) {
                                        var o = new ActiveXObject("Microsoft.XMLDOM");
                                        o.async = !1;
                                        try {
                                            o.loadXML(s.responseText)
                                        } catch (t) {
                                            o = void 0
                                        }
                                        if (!o || !o.documentElement || o.getElementsByTagName("parsererror").length) throw i.code = 500, i.message = "parseerror", "Invalid XML: " + s.responseText;
                                        r.xml = o
                                    }
                                } catch (t) {
                                    throw t
                                } finally {
                                    n(i.code, i.message, r, e)
                                }
                            }, s.onprogress = function () { }, s.onerror = function () {
                                n(500, "error", {
                                    text: s.responseText
                                })
                            }, o.data && (i = "string" === t.type(o.data) ? o.data : t.param(o.data)), s.open(r.type, r.url), s.send(i)
                        },
                        abort: function () {
                            s && s.abort()
                        }
                    }
                }
            })
        }
    }(window.jQuery)
}, function (t, e, n) {
    var i = n(0),
        r = n(3);
    i.define("ix", t.exports = function (t, e) {
        function n(t) {
            t && (z = {}, e.each(t, function (t) {
                z[t.slug] = t.value
            }), o())
        }

        function o() {
            ! function () {
                var e = t("[data-ix]");
                if (!e.length) return;
                e.each(u), e.each(a), O.length && (i.scroll.on(c), setTimeout(c, 1));
                E.length && i.load(l);
                A.length && setTimeout(f, j)
            }(), r.init(), i.redraw.up()
        }

        function a(n, o) {
            var a = t(o),
                u = a.attr("data-ix"),
                c = z[u];
            if (c) {
                var l = c.triggers;
                l && (m.style(a, c.style), e.each(l, function (t) {
                    function e() {
                        d(t, a, {
                            group: "A"
                        })
                    }

                    function n() {
                        d(t, a, {
                            group: "B"
                        })
                    }
                    var o = {},
                        u = t.type,
                        c = t.stepsB && t.stepsB.length;
                    if ("load" !== u) {
                        if ("click" === u) return a.on("click" + w, function (e) {
                            i.validClick(e.currentTarget) && ("#" === a.attr("href") && e.preventDefault(), d(t, a, {
                                group: o.clicked ? "B" : "A"
                            }), c && (o.clicked = !o.clicked))
                        }), void (T = T.add(a));
                        if ("hover" === u) return a.on("mouseenter" + w, e), a.on("mouseleave" + w, n), void (T = T.add(a));
                        if ("scroll" !== u) {
                            var l = C[u];
                            if (l) {
                                var f = a.closest(l);
                                return f.on(r.types.INTRO, e).on(r.types.OUTRO, n), void (T = T.add(f))
                            }
                        } else O.push({
                            el: a,
                            trigger: t,
                            state: {
                                active: !1
                            },
                            offsetTop: s(t.offsetTop),
                            offsetBot: s(t.offsetBot)
                        })
                    } else t.preload && !x ? E.push(e) : A.push(e)
                }))
            }
        }

        function s(t) {
            if (!t) return 0;
            t = String(t);
            var e = parseInt(t, 10);
            return e != e ? 0 : (t.indexOf("%") > 0 && (e /= 100) >= 1 && (e = .999), e)
        }

        function u(e, n) {
            t(n).off(w)
        }

        function c() {
            for (var t = g.scrollTop(), e = g.height(), n = O.length, i = 0; i < n; i++) {
                var r = O[i],
                    o = r.el,
                    a = r.trigger,
                    s = a.stepsB && a.stepsB.length,
                    u = r.state,
                    c = o.offset().top,
                    l = o.outerHeight(),
                    f = r.offsetTop,
                    h = r.offsetBot;
                f < 1 && f > 0 && (f *= e), h < 1 && h > 0 && (h *= e);
                var p = c + l - f >= t && c + h <= t + e;
                p !== u.active && ((!1 !== p || s) && (u.active = p, d(a, o, {
                    group: p ? "A" : "B"
                })))
            }
        }

        function l() {
            for (var t = E.length, e = 0; e < t; e++) E[e]()
        }

        function f() {
            for (var t = A.length, e = 0; e < t; e++) A[e]()
        }

        function d(e, n, r, o) {
            function a() {
                if (l) return d(e, n, r, !0);
                "auto" === g.width && m.set({
                    width: "auto"
                }), "auto" === g.height && m.set({
                    height: "auto"
                }), s && s()
            }
            var s = (r = r || {}).done,
                u = e.preserve3d;
            if (!p || r.force) {
                var c = r.group || "A",
                    l = e["loop" + c],
                    f = e["steps" + c];
                if (f && f.length) {
                    if (f.length < 2 && (l = !1), !o) {
                        var v = e.selector;
                        v && (n = e.descend ? n.find(v) : e.siblings ? n.siblings(v) : t(v), x && n.attr("data-ix-affect", 1)), k && n.addClass("w-ix-emptyfix"), u && n.css("transform-style", "preserve-3d")
                    }
                    for (var m = b(n), g = {
                        omit3d: !u
                    }, w = 0; w < f.length; w++) ! function (t, e, n) {
                        var r = "add",
                            o = "start";
                        n.start && (r = o = "then");
                        var a = e.transition;
                        if (a) {
                            a = a.split(",");
                            for (var s = 0; s < a.length; s++) {
                                var u = a[s];
                                t[r](u)
                            }
                        }
                        var c = h(e, n) || {};
                        null != c.width && (n.width = c.width);
                        null != c.height && (n.height = c.height);
                        if (null == a) {
                            n.start ? t.then(function () {
                                var e = this.queue;
                                this.set(c), c.display && (t.redraw(), i.redraw.up()), this.queue = e, this.next()
                            }) : (t.set(c), c.display && (t.redraw(), i.redraw.up()));
                            var l = c.wait;
                            null != l && (t.wait(l), n.start = !0)
                        } else {
                            if (c.display) {
                                var f = c.display;
                                delete c.display, n.start ? t.then(function () {
                                    var t = this.queue;
                                    this.set({
                                        display: f
                                    }).redraw(), i.redraw.up(), this.queue = t, this.next()
                                }) : (t.set({
                                    display: f
                                }).redraw(), i.redraw.up())
                            }
                            t[o](c), n.start = !0
                        }
                    }(m, f[w], g);
                    g.start ? m.then(a) : a()
                }
            }
        }

        function h(t, e) {
            var n = e && e.omit3d,
                i = {},
                r = !1;
            for (var o in t) "transition" !== o && "keysort" !== o && (!n || "z" !== o && "rotateX" !== o && "rotateY" !== o && "scaleZ" !== o) && (i[o] = t[o], r = !0);
            return r ? i : null
        }
        var p, v, m = {},
            g = t(window),
            w = ".w-ix",
            b = t.tram,
            y = i.env,
            x = y(),
            k = y.chrome && y.chrome < 35,
            _ = "none 0s ease 0s",
            T = t(),
            z = {},
            O = [],
            E = [],
            A = [],
            j = 1,
            C = {
                tabs: ".w-tab-link, .w-tab-pane",
                dropdown: ".w-dropdown",
                slider: ".w-slide",
                navbar: ".w-nav"
            };
        return m.init = function (t) {
            setTimeout(function () {
                n(t)
            }, 1)
        }, m.preview = function () {
            p = !1, j = 100, setTimeout(function () {
                n(window.__wf_ix)
            }, 1)
        }, m.design = function () {
            p = !0, m.destroy()
        }, m.destroy = function () {
            v = !0, T.each(u), i.scroll.off(c), r.async(), O = [], E = [], A = []
        }, m.ready = function () {
            if (x) return y("design") ? m.design() : m.preview();
            z && v && (v = !1, o())
        }, m.run = d, m.style = x ? function (e, n) {
            var i = b(e);
            if (!t.isEmptyObject(n)) {
                e.css("transition", "");
                var r = e.css("transition");
                r === _ && (r = i.upstream = null), i.upstream = _, i.set(h(n)), i.upstream = r
            }
        } : function (t, e) {
            b(t).set(h(e))
        }, m
    })
}, function (t, e, n) {
    var i = n(0);
    i.define("links", t.exports = function (t, e) {
        function n() {
            var t = c.scrollTop(),
                n = c.height();
            e.each(a, function (e) {
                var i = e.link,
                    o = e.sec,
                    a = o.offset().top,
                    s = o.outerHeight(),
                    u = .5 * n,
                    c = o.is(":visible") && a + s - u >= t && a + u <= t + n;
                e.active !== c && (e.active = c, r(i, h, c))
            })
        }

        function r(t, e, n) {
            var i = t.hasClass(e);
            n && i || (n || i) && (n ? t.addClass(e) : t.removeClass(e))
        }
        var o, a, s, u = {},
            c = t(window),
            l = i.env(),
            f = window.location,
            d = document.createElement("a"),
            h = "w--current",
            p = /^#[\w:.-]+$/,
            v = /index\.(html|php)$/,
            m = /\/$/;
        return u.ready = u.design = u.preview = function () {
            o = l && i.env("design"), s = i.env("slug") || f.pathname || "", i.scroll.off(n), a = [];
            for (var e = document.links, u = 0; u < e.length; ++u) ! function (e) {
                var n = o && e.getAttribute("href-disabled") || e.getAttribute("href");
                if (d.href = n, !(n.indexOf(":") >= 0)) {
                    var i = t(e);
                    if (0 === n.indexOf("#") && p.test(n)) {
                        var u = t(n);
                        u.length && a.push({
                            link: i,
                            sec: u,
                            active: !1
                        })
                    } else if ("#" !== n) {
                        var c = d.href === f.href || n === s || v.test(n) && m.test(s);
                        r(i, h, c)
                    }
                }
            }(e[u]);
            a.length && (i.scroll.on(n), n())
        }, u
    })
}, function (t, e, n) {
    var i = n(0),
        r = n(1);
    i.define("navbar", t.exports = function (t, e) {
        function n() {
            i.resize.off(o)
        }

        function o() {
            m.each(f)
        }

        function a(n, r) {
            var o = t(r),
                a = t.data(r, T);
            a || (a = t.data(r, T, {
                open: !1,
                el: o,
                config: {}
            })), a.menu = o.find(".w-nav-menu"), a.links = a.menu.find(".w-nav-link"), a.dropdowns = a.menu.find(".w-dropdown"), a.button = o.find(".w-nav-button"), a.container = o.find(".w-container"), a.outside = function (n) {
                n.outside && x.off("tap" + T, n.outside);
                return e.debounce(function (e) {
                    if (n.open) {
                        var i = t(e.target).closest(".w-nav-menu");
                        n.menu.is(i) || p(n)
                    }
                })
            }(a), a.el.off(T), a.button.off(T), a.menu.off(T), c(a), g ? (u(a), a.el.on("setting" + T, function (t) {
                return function (n, i) {
                    i = i || {};
                    var r = y.width();
                    c(t), !0 === i.open && d(t, !0), !1 === i.open && p(t, !0), t.open && e.defer(function () {
                        r !== y.width() && l(t)
                    })
                }
            }(a))) : (! function (e) {
                if (e.overlay) return;
                e.overlay = t(_).appendTo(e.el), e.parent = e.menu.parent(), p(e, !0)
            }(a), a.button.on("tap" + T, function (t) {
                return e.debounce(function () {
                    t.open ? p(t) : d(t)
                })
            }(a)), a.menu.on("click" + T, "a", function (e) {
                return function (n) {
                    var r = t(this),
                        o = r.attr("href");
                    i.validClick(n.currentTarget) ? o && 0 === o.indexOf("#") && e.open && p(e) : n.preventDefault()
                }
            }(a))), f(n, r)
        }

        function s(e, n) {
            var i = t.data(n, T);
            i && (u(i), t.removeData(n, T))
        }

        function u(t) {
            t.overlay && (p(t, !0), t.overlay.remove(), t.overlay = null)
        }

        function c(t) {
            var n = {},
                i = t.config || {},
                r = n.animation = t.el.attr("data-animation") || "default";
            n.animOver = /^over/.test(r), n.animDirect = /left$/.test(r) ? -1 : 1, i.animation !== r && t.open && e.defer(l, t), n.easing = t.el.attr("data-easing") || "ease", n.easing2 = t.el.attr("data-easing2") || "ease";
            var o = t.el.attr("data-duration");
            n.duration = null != o ? Number(o) : 400, n.docHeight = t.el.attr("data-doc-height"), t.config = n
        }

        function l(t) {
            t.open && (p(t, !0), d(t, !0))
        }

        function f(e, n) {
            var i = t.data(n, T),
                r = i.collapsed = "none" !== i.button.css("display");
            if (!i.open || r || g || p(i, !0), i.container.length) {
                var o = function (e) {
                    var n = e.container.css(C);
                    "none" === n && (n = "");
                    return function (e, i) {
                        (i = t(i)).css(C, ""), "none" === i.css(C) && i.css(C, n)
                    }
                }(i);
                i.links.each(o), i.dropdowns.each(o)
            }
            i.open && h(i)
        }

        function d(t, e) {
            if (!t.open) {
                t.open = !0, t.menu.addClass(O), t.links.addClass(E), t.button.addClass(z);
                var n = t.config;
                "none" !== n.animation && b.support.transform || (e = !0);
                var r = h(t),
                    o = t.menu.outerHeight(!0),
                    a = t.menu.outerWidth(!0),
                    s = t.el.height(),
                    u = t.el[0];
                if (f(0, u), A.intro(0, u), i.redraw.up(), g || x.on("tap" + T, t.outside), !e) {
                    var c = "transform " + n.duration + "ms " + n.easing;
                    if (t.overlay && (j = t.menu.prev(), t.overlay.show().append(t.menu)), n.animOver) return b(t.menu).add(c).set({
                        x: n.animDirect * a,
                        height: r
                    }).start({
                        x: 0
                    }), void (t.overlay && t.overlay.width(a));
                    var l = s + o;
                    b(t.menu).add(c).set({
                        y: -l
                    }).start({
                        y: 0
                    })
                }
            }
        }

        function h(t) {
            var e = t.config,
                n = e.docHeight ? x.height() : v.height();
            return e.animOver ? t.menu.height(n) : "fixed" !== t.el.css("position") && (n -= t.el.height()), t.overlay && t.overlay.height(n), n
        }

        function p(t, e) {
            function n() {
                t.menu.height(""), b(t.menu).set({
                    x: 0,
                    y: 0
                }), t.menu.removeClass(O), t.links.removeClass(E), t.overlay && t.overlay.children().length && (j.length ? t.menu.insertAfter(j) : t.menu.prependTo(t.parent), t.overlay.attr("style", "").hide()), t.el.triggerHandler("w-close")
            }
            if (t.open) {
                t.open = !1, t.button.removeClass(z);
                var i = t.config;
                if (("none" === i.animation || !b.support.transform || i.duration <= 0) && (e = !0), A.outro(0, t.el[0]), x.off("tap" + T, t.outside), e) return b(t.menu).stop(), void n();
                var r = "transform " + i.duration + "ms " + i.easing2,
                    o = t.menu.outerHeight(!0),
                    a = t.menu.outerWidth(!0),
                    s = t.el.height();
                if (i.animOver) b(t.menu).add(r).start({
                    x: a * i.animDirect
                }).then(n);
                else {
                    var u = s + o;
                    b(t.menu).add(r).start({
                        y: -u
                    }).then(n)
                }
            }
        }
        var v, m, g, w = {},
            b = t.tram,
            y = t(window),
            x = t(document),
            k = i.env(),
            _ = '<div class="w-nav-overlay" data-wf-ignore />',
            T = ".w-nav",
            z = "w--open",
            O = "w--nav-menu-open",
            E = "w--nav-link-open",
            A = r.triggers,
            j = t();
        w.ready = w.design = w.preview = function () {
            g = k && i.env("design"), v = t(document.body), (m = x.find(T)).length && (m.each(a), n(), i.resize.on(o))
        }, w.destroy = function () {
            j = t(), n(), m && m.length && m.each(s)
        };
        var C = "max-width";
        return w
    })
}, function (t, e, n) {
    var i = n(0);
    i.define("scroll", t.exports = function (t) {
        function e(e, n) {
            if (s.test(e)) {
                var u = t("#" + e);
                if (u.length) {
                    if (n && (n.preventDefault(), n.stopPropagation()), o.hash !== e && a && a.pushState && (!i.env.chrome || "file:" !== o.protocol)) {
                        (a.state && a.state.hash) !== e && a.pushState({
                            hash: e
                        }, "", "#" + e)
                    }
                    var c = i.env("editor") ? ".w-editor-body" : "body",
                        l = t("header, " + c + " > .header, " + c + " > .w-nav:not([data-no-scroll])"),
                        f = "fixed" === l.css("position") ? l.outerHeight() : 0;
                    r.setTimeout(function () {
                        ! function (e, n) {
                            var i = t(r).scrollTop(),
                                o = e.offset().top - n;
                            if ("mid" === e.data("scroll")) {
                                var a = t(r).height() - n,
                                    s = e.outerHeight();
                                s < a && (o -= Math.round((a - s) / 2))
                            }
                            var u = 1;
                            t("body").add(e).each(function () {
                                var e = parseFloat(t(this).attr("data-scroll-time"), 10);
                                !isNaN(e) && (0 === e || e > 0) && (u = e)
                            }), Date.now || (Date.now = function () {
                                return (new Date).getTime()
                            });
                            var c = Date.now(),
                                l = r.requestAnimationFrame || r.mozRequestAnimationFrame || r.webkitRequestAnimationFrame || function (t) {
                                    r.setTimeout(t, 15)
                                },
                                f = (472.143 * Math.log(Math.abs(i - o) + 125) - 2e3) * u;
                            ! function t() {
                                var e = Date.now() - c;
                                r.scroll(0, function (t, e, n, i) {
                                    if (n > i) return e;
                                    return t + (e - t) * function (t) {
                                        return t < .5 ? 4 * t * t * t : (t - 1) * (2 * t - 2) * (2 * t - 2) + 1
                                    }(n / i)
                                }(i, o, e, f)), e <= f && l(t)
                            }()
                        }(u, f)
                    }, n ? 0 : 300)
                }
            }
        }
        var n = t(document),
            r = window,
            o = r.location,
            a = function () {
                try {
                    return Boolean(r.frameElement)
                } catch (t) {
                    return !0
                }
            }() ? null : r.history,
            s = /^[a-zA-Z0-9][\w:.-]*$/;
        return {
            ready: function () {
                o.hash && e(o.hash.substring(1));
                var r = o.href.split("#")[0];
                n.on("click", "a", function (n) {
                    if (!(i.env("design") || window.$.mobile && t(n.currentTarget).hasClass("ui-link")))
                        if ("#" !== this.getAttribute("href")) {
                            var o = this.href.split("#"),
                                a = o[0] === r ? o[1] : null;
                            a && e(a, n)
                        } else n.preventDefault()
                })
            }
        }
    })
}, function (t, e, n) {
    var i = n(0),
        r = n(1);
    i.define("slider", t.exports = function (t, e) {
        function n() {
            (w = T.find(O)).length && (w.filter(":visible").each(s), x = null, y || (o(), i.resize.on(a), i.redraw.on(k.redraw)))
        }

        function o() {
            i.resize.off(a), i.redraw.off(k.redraw)
        }

        function a() {
            w.filter(":visible").each(m)
        }

        function s(e, n) {
            var i = t(n),
                r = t.data(n, O);
            if (r || (r = t.data(n, O, {
                index: 0,
                depth: 1,
                el: i,
                config: {}
            })), r.mask = i.children(".w-slider-mask"), r.left = i.children(".w-slider-arrow-left"), r.right = i.children(".w-slider-arrow-right"), r.nav = i.children(".w-slider-nav"), r.slides = r.mask.children(".w-slide"), r.slides.each(A.reset), x && (r.maskWidth = 0), !_.support.transform) return r.left.hide(), r.right.hide(), r.nav.hide(), void (y = !0);
            r.el.off(O), r.left.off(O), r.right.off(O), r.nav.off(O), u(r), b ? (r.el.on("setting" + O, p(r)), h(r), r.hasTimer = !1) : (r.el.on("swipe" + O, p(r)), r.left.on("tap" + O, l(r)), r.right.on("tap" + O, f(r)), r.config.autoplay && !r.hasTimer && (r.hasTimer = !0, r.timerCount = 1, d(r))), r.nav.on("tap" + O, "> div", p(r)), z || r.mask.contents().filter(function () {
                return 3 === this.nodeType
            }).remove(), m(e, n)
        }

        function u(t) {
            var e = {};
            e.crossOver = 0, e.animation = t.el.attr("data-animation") || "slide", "outin" === e.animation && (e.animation = "cross", e.crossOver = .5), e.easing = t.el.attr("data-easing") || "ease";
            var n = t.el.attr("data-duration");
            if (e.duration = null != n ? parseInt(n, 10) : 500, c(t.el.attr("data-infinite")) && (e.infinite = !0), c(t.el.attr("data-disable-swipe")) && (e.disableSwipe = !0), c(t.el.attr("data-hide-arrows")) ? e.hideArrows = !0 : t.config.hideArrows && (t.left.show(), t.right.show()), c(t.el.attr("data-autoplay"))) {
                e.autoplay = !0, e.delay = parseInt(t.el.attr("data-delay"), 10) || 2e3, e.timerMax = parseInt(t.el.attr("data-autoplay-limit"), 10);
                var i = "mousedown" + O + " touchstart" + O;
                b || t.el.off(i).one(i, function () {
                    h(t)
                })
            }
            var r = t.right.width();
            e.edge = r ? r + 40 : 100, t.config = e
        }

        function c(t) {
            return "1" === t || "true" === t
        }

        function l(t) {
            return function () {
                v(t, {
                    index: t.index - 1,
                    vector: -1
                })
            }
        }

        function f(t) {
            return function () {
                v(t, {
                    index: t.index + 1,
                    vector: 1
                })
            }
        }

        function d(t) {
            h(t);
            var e = t.config,
                n = e.timerMax;
            n && t.timerCount++ > n || (t.timerId = window.setTimeout(function () {
                null == t.timerId || b || (f(t)(), d(t))
            }, e.delay))
        }

        function h(t) {
            window.clearTimeout(t.timerId), t.timerId = null
        }

        function p(r) {
            return function (o, a) {
                a = a || {};
                var s = r.config;
                if (b && "setting" === o.type) {
                    if ("prev" === a.select) return l(r)();
                    if ("next" === a.select) return f(r)();
                    if (u(r), g(r), null == a.select) return;
                    ! function (i, r) {
                        var o = null;
                        r === i.slides.length && (n(), g(i)), e.each(i.anchors, function (e, n) {
                            t(e.els).each(function (e, i) {
                                t(i).index() === r && (o = n)
                            })
                        }), null != o && v(i, {
                            index: o,
                            immediate: !0
                        })
                    }(r, a.select)
                } else if ("swipe" !== o.type) r.nav.has(o.target).length && v(r, {
                    index: t(o.target).index()
                });
                else {
                    if (s.disableSwipe) return;
                    if (i.env("editor")) return;
                    if ("left" === a.direction) return f(r)();
                    if ("right" === a.direction) return l(r)()
                }
            }
        }

        function v(e, n) {
            function i() {
                d = t(o[e.index].els), p = e.slides.not(d), "slide" !== v && (f.visibility = "hidden"), _(p).set(f)
            }
            n = n || {};
            var r = e.config,
                o = e.anchors;
            e.previous = e.index;
            var a = n.index,
                s = {};
            a < 0 ? (a = o.length - 1, r.infinite && (s.x = -e.endX, s.from = 0, s.to = o[0].width)) : a >= o.length && (a = 0, r.infinite && (s.x = o[o.length - 1].width, s.from = -o[o.length - 1].x, s.to = s.from - s.x)), e.index = a;
            var u = e.nav.children().eq(e.index).addClass("w-active");
            e.nav.children().not(u).removeClass("w-active"), r.hideArrows && (e.index === o.length - 1 ? e.right.hide() : e.right.show(), 0 === e.index ? e.left.hide() : e.left.show());
            var c = e.offsetX || 0,
                l = e.offsetX = -o[e.index].x,
                f = {
                    x: l,
                    opacity: 1,
                    visibility: ""
                },
                d = t(o[e.index].els),
                h = t(o[e.previous] && o[e.previous].els),
                p = e.slides.not(d),
                v = r.animation,
                m = r.easing,
                g = Math.round(r.duration),
                w = n.vector || (e.index > e.previous ? 1 : -1),
                y = "opacity " + g + "ms " + m,
                k = "transform " + g + "ms " + m;
            if (b || (d.each(A.intro), p.each(A.outro)), n.immediate && !x) return _(d).set(f), void i();
            if (e.index !== e.previous) {
                if ("cross" === v) {
                    var T = Math.round(g - g * r.crossOver),
                        z = Math.round(g - T);
                    return y = "opacity " + T + "ms " + m, _(h).set({
                        visibility: ""
                    }).add(y).start({
                        opacity: 0
                    }), void _(d).set({
                        visibility: "",
                        x: l,
                        opacity: 0,
                        zIndex: e.depth++
                    }).add(y).wait(z).then({
                        opacity: 1
                    }).then(i)
                }
                return "fade" === v ? (_(h).set({
                    visibility: ""
                }).stop(), void _(d).set({
                    visibility: "",
                    x: l,
                    opacity: 0,
                    zIndex: e.depth++
                }).add(y).start({
                    opacity: 1
                }).then(i)) : "over" === v ? (f = {
                    x: e.endX
                }, _(h).set({
                    visibility: ""
                }).stop(), void _(d).set({
                    visibility: "",
                    zIndex: e.depth++,
                    x: l + o[e.index].width * w
                }).add(k).start({
                    x: l
                }).then(i)) : void (r.infinite && s.x ? (_(e.slides.not(h)).set({
                    visibility: "",
                    x: s.x
                }).add(k).start({
                    x: l
                }), _(h).set({
                    visibility: "",
                    x: s.from
                }).add(k).start({
                    x: s.to
                }), e.shifted = h) : (r.infinite && e.shifted && (_(e.shifted).set({
                    visibility: "",
                    x: c
                }), e.shifted = null), _(e.slides).set({
                    visibility: ""
                }).add(k).start({
                    x: l
                })))
            }
        }

        function m(e, n) {
            var i = t.data(n, O);
            if (i) return function (t) {
                var e = t.mask.width();
                if (t.maskWidth !== e) return t.maskWidth = e, !0;
                return !1
            }(i) ? g(i) : void (b && function (e) {
                var n = 0;
                if (e.slides.each(function (e, i) {
                    n += t(i).outerWidth(!0)
                }), e.slidesWidth !== n) return e.slidesWidth = n, !0;
                return !1
            }(i) && g(i))
        }

        function g(e) {
            var n = 1,
                i = 0,
                r = 0,
                o = 0,
                a = e.maskWidth,
                s = a - e.config.edge;
            s < 0 && (s = 0), e.anchors = [{
                els: [],
                x: 0,
                width: 0
            }], e.slides.each(function (u, c) {
                r - i > s && (n++ , i += a, e.anchors[n - 1] = {
                    els: [],
                    x: r,
                    width: 0
                }), o = t(c).outerWidth(!0), r += o, e.anchors[n - 1].width += o, e.anchors[n - 1].els.push(c)
            }), e.endX = r, b && (e.pages = null), e.nav.length && e.pages !== n && (e.pages = n, function (e) {
                var n, i = [],
                    r = e.el.attr("data-nav-spacing");
                r && (r = parseFloat(r) + "px");
                for (var o = 0; o < e.pages; o++) n = t(E), e.nav.hasClass("w-num") && n.text(o + 1), null != r && n.css({
                    "margin-left": r,
                    "margin-right": r
                }), i.push(n);
                e.nav.empty().append(i)
            }(e));
            var u = e.index;
            u >= n && (u = n - 1), v(e, {
                immediate: !0,
                index: u
            })
        }
        var w, b, y, x, k = {},
            _ = t.tram,
            T = t(document),
            z = i.env(),
            O = ".w-slider",
            E = '<div class="w-slider-dot" data-wf-ignore />',
            A = r.triggers;
        return k.ready = function () {
            b = i.env("design"), n()
        }, k.design = function () {
            b = !0, n()
        }, k.preview = function () {
            b = !1, n()
        }, k.redraw = function () {
            x = !0, n()
        }, k.destroy = o, k
    })
}, function (t, e, n) {
    var i = n(0),
        r = n(1);
    i.define("tabs", t.exports = function (t) {
        function e() {
            c = v && i.env("design"), (u = d.find(g)).length && (u.each(a), i.env("preview") && !x && u.each(o), n(), i.redraw.on(l.redraw))
        }

        function n() {
            i.redraw.off(l.redraw)
        }

        function o(e, n) {
            var i = t.data(n, g);
            i && (i.links && i.links.each(y.reset), i.panes && i.panes.each(y.reset))
        }

        function a(e, n) {
            var i = t(n),
                r = t.data(n, g);
            if (r || (r = t.data(n, g, {
                el: i,
                config: {}
            })), r.current = null, r.menu = i.children(".w-tab-menu"), r.links = r.menu.children(".w-tab-link"), r.content = i.children(".w-tab-content"), r.panes = r.content.children(".w-tab-pane"), r.el.off(g), r.links.off(g), function (t) {
                var e = {};
                e.easing = t.el.attr("data-easing") || "ease";
                var n = parseInt(t.el.attr("data-duration-in"), 10);
                n = e.intro = n == n ? n : 0;
                var i = parseInt(t.el.attr("data-duration-out"), 10);
                i = e.outro = i == i ? i : 0, e.immediate = !n && !i, t.config = e
            }(r), !c) {
                r.links.on("click" + g, function (t) {
                    return function (e) {
                        var n = e.currentTarget.getAttribute(m);
                        n && s(t, {
                            tab: n
                        })
                    }
                }(r));
                var o = r.links.filter("." + w).attr(m);
                o && s(r, {
                    tab: o,
                    immediate: !0
                })
            }
        }

        function s(e, n) {
            function r() {
                if (d.removeClass(b).css({
                    opacity: "",
                    transition: "",
                    transform: "",
                    width: "",
                    height: ""
                }), l.addClass(b).each(y.intro), i.redraw.up(), !o.intro) return f(l).set({
                    opacity: 1
                });
                f(l).set({
                    opacity: 0
                }).redraw().add("opacity " + o.intro + "ms " + a, {
                    fallback: p
                }).start({
                    opacity: 1
                })
            }
            n = n || {};
            var o = e.config,
                a = o.easing,
                s = n.tab;
            if (s !== e.current) {
                e.current = s, e.links.each(function (e, n) {
                    var i = t(n);
                    n.getAttribute(m) === s ? i.addClass(w).each(y.intro) : i.hasClass(w) && i.removeClass(w).each(y.outro)
                });
                var u = [],
                    c = [];
                e.panes.each(function (e, n) {
                    var i = t(n);
                    n.getAttribute(m) === s ? u.push(n) : i.hasClass(b) && c.push(n)
                });
                var l = t(u),
                    d = t(c);
                if (n.immediate || o.immediate) return l.addClass(b).each(y.intro), d.removeClass(b), void (x || i.redraw.up());
                d.length && o.outro ? (d.each(y.outro), f(d).add("opacity " + o.outro + "ms " + a, {
                    fallback: p
                }).start({
                    opacity: 0
                }).then(r)) : r()
            }
        }
        var u, c, l = {},
            f = t.tram,
            d = t(document),
            h = i.env,
            p = h.safari,
            v = h(),
            m = "data-w-tab",
            g = ".w-tabs",
            w = "w--current",
            b = "w--tab-active",
            y = r.triggers,
            x = !1;
        return l.ready = l.design = l.preview = e, l.redraw = function () {
            x = !0, e(), x = !1
        }, l.destroy = function () {
            (u = d.find(g)).length && (u.each(o), n())
        }, l
    })
}, function (t, e, n) {
    n(0).define("touch", t.exports = function (t) {
        function e(e, n, i) {
            var r = t.Event(e, {
                originalEvent: n
            });
            t(n.target).trigger(r, i)
        }
        var n = {},
            i = !document.addEventListener,
            r = window.getSelection;
        return i && (t.event.special.tap = {
            bindType: "click",
            delegateType: "click"
        }), n.init = function (n) {
            return i ? null : (n = "string" == typeof n ? t(n).get(0) : n) ? new function (t) {
                function n(t) {
                    var e = t.touches;
                    e && e.length > 1 || (l = !0, f = !1, e ? (d = !0, s = e[0].clientX, u = e[0].clientY) : (s = t.clientX, u = t.clientY), c = s)
                }

                function i(t) {
                    if (l) {
                        if (d && "mousemove" === t.type) return t.preventDefault(), void t.stopPropagation();
                        var n = t.touches,
                            i = n ? n[0].clientX : t.clientX,
                            o = n ? n[0].clientY : t.clientY,
                            p = i - c;
                        c = i, Math.abs(p) > h && r && "" === String(r()) && (e("swipe", t, {
                            direction: p > 0 ? "right" : "left"
                        }), a()), (Math.abs(i - s) > 10 || Math.abs(o - u) > 10) && (f = !0)
                    }
                }

                function o(t) {
                    if (l) {
                        if (l = !1, d && "mouseup" === t.type) return t.preventDefault(), t.stopPropagation(), void (d = !1);
                        f || e("tap", t)
                    }
                }

                function a() {
                    l = !1
                }
                var s, u, c, l = !1,
                    f = !1,
                    d = !1,
                    h = Math.min(Math.round(.04 * window.innerWidth), 40);
                t.addEventListener("touchstart", n, !1), t.addEventListener("touchmove", i, !1), t.addEventListener("touchend", o, !1), t.addEventListener("touchcancel", a, !1), t.addEventListener("mousedown", n, !1), t.addEventListener("mousemove", i, !1), t.addEventListener("mouseup", o, !1), t.addEventListener("mouseout", a, !1), this.destroy = function () {
                    t.removeEventListener("touchstart", n, !1), t.removeEventListener("touchmove", i, !1), t.removeEventListener("touchend", o, !1), t.removeEventListener("touchcancel", a, !1), t.removeEventListener("mousedown", n, !1), t.removeEventListener("mousemove", i, !1), t.removeEventListener("mouseup", o, !1), t.removeEventListener("mouseout", a, !1), t = null
                }
            }(n) : null
        }, n.instance = n.init(document), n
    })
}]);
/**
 * ----------------------------------------------------------------------
 * Webflow: Interactions: Init
 */
Webflow.require('ix').init([{
    "slug": "preloader",
    "name": "Preloader",
    "value": {
        "style": {
            "display": "flex",
            "opacity": 1
        },
        "triggers": [{
            "type": "load",
            "preload": true,
            "stepsA": [{
                "wait": "100ms"
            }, {
                "opacity": 0,
                "transition": "opacity 500ms ease 0"
            }, {
                "display": "none"
            }],
            "stepsB": []
        }]
    }
}, {
    "slug": "home-herobg",
    "name": "Home HeroBG",
    "value": {
        "style": {
            "opacity": 0,
            "x": "-20px",
            "y": "0px",
            "z": "0px",
            "skewX": "3deg",
            "skewY": "0deg"
        },
        "triggers": [{
            "type": "load",
            "preload": true,
            "stepsA": [{
                "wait": "1000ms"
            }, {
                "opacity": 1,
                "transition": "opacity 1000ms ease 0, transform 1000ms ease 0",
                "x": "0px",
                "y": "0px",
                "z": "0px",
                "skewX": "5deg",
                "skewY": "0deg"
            }],
            "stepsB": []
        }]
    }
}, {
    "slug": "home-hero-heading",
    "name": "Home Hero Heading",
    "value": {
        "style": {
            "opacity": 0,
            "x": "0px",
            "y": "20px",
            "z": "0px"
        },
        "triggers": [{
            "type": "load",
            "preload": true,
            "stepsA": [{
                "wait": "1000ms"
            }, {
                "opacity": 1,
                "transition": "transform 1000ms ease 0, opacity 1000ms ease 0",
                "x": "0px",
                "y": "0px",
                "z": "0px"
            }],
            "stepsB": []
        }]
    }
}, {
    "slug": "home-hero-subtext",
    "name": "Home Hero Subtext",
    "value": {
        "style": {
            "opacity": 0,
            "x": "0px",
            "y": "20px",
            "z": "0px"
        },
        "triggers": [{
            "type": "load",
            "preload": true,
            "stepsA": [{
                "wait": "2000ms"
            }, {
                "opacity": 1,
                "transition": "transform 1000ms ease 0, opacity 1000ms ease 0",
                "x": "0px",
                "y": "0px",
                "z": "0px"
            }],
            "stepsB": []
        }]
    }
}, {
    "slug": "home-hero-video-heading",
    "name": "Home Hero Video Heading",
    "value": {
        "style": {
            "opacity": 0,
            "x": "0px",
            "y": "20px",
            "z": "0px"
        },
        "triggers": [{
            "type": "load",
            "preload": true,
            "stepsA": [{
                "wait": "3000ms"
            }, {
                "opacity": 1,
                "transition": "transform 1000ms ease 0, opacity 1000ms ease 0",
                "x": "0px",
                "y": "0px",
                "z": "0px"
            }],
            "stepsB": []
        }]
    }
}, {
    "slug": "home-hero-video-button",
    "name": "Home Hero Video Button",
    "value": {
        "style": {
            "opacity": 0,
            "x": "0px",
            "y": "20px",
            "z": "0px"
        },
        "triggers": [{
            "type": "load",
            "preload": true,
            "stepsA": [{
                "wait": "3500ms"
            }, {
                "opacity": 1,
                "transition": "transform 1000ms ease 0, opacity 1000ms ease 0",
                "x": "0px",
                "y": "0px",
                "z": "0px"
            }],
            "stepsB": []
        }, {
            "type": "click",
            "stepsA": [{
                "opacity": 1,
                "transition": "opacity 200 ease 0"
            }],
            "stepsB": []
        }]
    }
}, {
    "slug": "home-hero-arrow",
    "name": "Home Hero Arrow",
    "value": {
        "style": {
            "opacity": 0
        },
        "triggers": [{
            "type": "load",
            "preload": true,
            "loopA": true,
            "stepsA": [{
                "wait": "2500ms"
            }, {
                "opacity": 1,
                "transition": "transform 1000ms ease 0, opacity 1000ms ease 0"
            }],
            "stepsB": []
        }]
    }
}, {
    "slug": "home-modal-video-close",
    "name": "Home Modal Video  -Close",
    "value": {
        "style": {},
        "triggers": [{
            "type": "click",
            "stepsA": [{
                "opacity": 0,
                "transition": "transform 200 ease 0, opacity 500ms ease 0"
            }, {
                "display": "none"
            }],
            "stepsB": []
        }]
    }
}, {
    "slug": "home-linkblock-sensingplus",
    "name": "Home-LINKblock-SENSINGplus",
    "value": {
        "style": {},
        "triggers": [{
            "type": "hover",
            "selector": ".exploreproductslink__maintype",
            "descend": true,
            "preserve3d": true,
            "stepsA": [{
                "transition": "transform 200 ease 0",
                "x": "0px",
                "y": "-20px",
                "z": "0px"
            }],
            "stepsB": [{
                "transition": "transform 200 ease 0",
                "x": "0px",
                "y": "0px",
                "z": "0px"
            }]
        }, {
            "type": "hover",
            "selector": ".exploreproductslink__subtype",
            "descend": true,
            "preserve3d": true,
            "stepsA": [{
                "wait": "1000ms",
                "transition": "transform 200 ease 0",
                "x": "0px",
                "y": "-10px",
                "z": "0px"
            }],
            "stepsB": [{
                "wait": "1000ms",
                "transition": "transform 200 ease 0",
                "x": "0px",
                "y": "0px",
                "z": "0px"
            }]
        }, {
            "type": "hover",
            "selector": ".home__explorelinkoverlay",
            "descend": true,
            "stepsA": [{
                "opacity": 1,
                "transition": "opacity 200 ease 0"
            }],
            "stepsB": [{
                "opacity": 0,
                "transition": "opacity 200 ease 0"
            }]
        }]
    }
}, {
    "slug": "fademoveonscroll",
    "name": "fadeMOVEonSCROLL",
    "value": {
        "style": {
            "opacity": 0,
            "x": "0px",
            "y": "20px",
            "z": "0px"
        },
        "triggers": [{
            "type": "scroll",
            "offsetTop": "0%",
            "offsetBot": "20%",
            "stepsA": [{
                "wait": "1000ms",
                "opacity": 1,
                "transition": "opacity 1000ms ease 0, transform 1000ms ease 0",
                "x": "0px",
                "y": "0px",
                "z": "0px"
            }],
            "stepsB": [{
                "opacity": 0,
                "transition": "opacity 200 ease 0, transform 200 ease 0",
                "x": "0px",
                "y": "-10px",
                "z": "0px"
            }]
        }]
    }
}, {
    "slug": "reveal-footer-nav",
    "name": "Reveal Footer Nav",
    "value": {
        "style": {
            "opacity": 0,
            "x": "0px",
            "y": "20px",
            "z": "0px"
        },
        "triggers": [{
            "type": "scroll",
            "offsetTop": "0%",
            "offsetBot": "20%",
            "stepsA": [{
                "wait": "1000ms",
                "opacity": 1,
                "transition": "opacity 1000ms ease 0, transform 1000ms ease 0",
                "x": "0px",
                "y": "0px",
                "z": "0px"
            }],
            "stepsB": [{
                "opacity": 0,
                "transition": "opacity 200 ease 0, transform 200 ease 0",
                "x": "0px",
                "y": "-10px",
                "z": "0px"
            }]
        }]
    }
}, {
    "slug": "fademoveonload",
    "name": "fadeMOVEonLOAD",
    "value": {
        "style": {
            "opacity": 0,
            "x": "0px",
            "y": "20px",
            "z": "0px"
        },
        "triggers": [{
            "type": "load",
            "stepsA": [{
                "opacity": 1,
                "transition": "transform 1000ms ease 0, opacity 1000ms ease 0",
                "x": "0px",
                "y": "0px",
                "z": "0px"
            }],
            "stepsB": []
        }]
    }
}, {
    "slug": "home-teaserapp",
    "name": "Home - TeaserApp",
    "value": {
        "style": {
            "opacity": 0.2,
            "x": "30%",
            "y": "20px",
            "z": "0px"
        },
        "triggers": [{
            "type": "scroll",
            "stepsA": [{
                "opacity": 1,
                "transition": "transform 1000ms ease 0, opacity 1000ms ease 0",
                "x": "30%",
                "y": "0px",
                "z": "0px"
            }],
            "stepsB": []
        }]
    }
}, {
    "slug": "menu-underlay-activate",
    "name": "Menu Underlay ACTIVATE",
    "value": {
        "style": {},
        "triggers": [{
            "type": "scroll",
            "selector": ".nav__desktop__underlayv2",
            "offsetBot": "75%",
            "stepsA": [{
                "wait": "1000ms",
                "opacity": 0.5,
                "transition": "opacity 200 ease 0"
            }],
            "stepsB": []
        }]
    }
}, {
    "slug": "nav-dropdown-fade",
    "name": "Nav Dropdown Fade",
    "value": {
        "style": {
            "opacity": 0,
            "x": "0px",
            "y": "-20px",
            "z": "0px"
        },
        "triggers": [{
            "type": "dropdown",
            "stepsA": [{
                "opacity": 1,
                "transition": "opacity 500ms ease 0, transform 500ms ease 0",
                "x": "0px",
                "y": "0px",
                "z": "0px"
            }],
            "stepsB": [{
                "opacity": 0,
                "transition": "transform 500ms ease 0, opacity 200 ease 0",
                "x": "0px",
                "y": "-20px",
                "z": "0px"
            }, {
                "opacity": 0,
                "transition": "opacity 500ms ease 0"
            }]
        }]
    }
}, {
    "slug": "nav-fade-in-on-load",
    "name": "Nav fade In on Load",
    "value": {
        "style": {
            "opacity": 0,
            "x": "0px",
            "y": "-20px",
            "z": "0px"
        },
        "triggers": [{
            "type": "load",
            "stepsA": [{
                "wait": "200ms"
            }, {
                "opacity": 1,
                "transition": "opacity 1000ms ease 0, transform 1000ms ease 0",
                "x": "0px",
                "y": "0px",
                "z": "0px"
            }],
            "stepsB": []
        }]
    }
}, {
    "slug": "hero-divider-animatewidth",
    "name": "hero__divider__animateWidth",
    "value": {
        "style": {
            "opacity": 0.5,
            "width": "0px"
        },
        "triggers": [{
            "type": "load",
            "stepsA": [{
                "wait": "200ms"
            }, {
                "opacity": 1,
                "width": "60%",
                "transition": "width 1000ms ease 0, opacity 1000ms ease 0"
            }],
            "stepsB": []
        }]
    }
}, {
    "slug": "hr-animateonscoll",
    "name": "hr__animateOnScoll",
    "value": {
        "style": {
            "opacity": 0.5,
            "width": "0px"
        },
        "triggers": [{
            "type": "scroll",
            "offsetBot": "20%",
            "stepsA": [{
                "wait": "200ms"
            }, {
                "opacity": 1,
                "width": "300px",
                "transition": "width 1000ms ease 0, opacity 1000ms ease 0"
            }],
            "stepsB": []
        }]
    }
}, {
    "slug": "expandablearea",
    "name": "expandableArea",
    "value": {
        "style": {
            "height": "88px"
        },
        "triggers": [{
            "type": "click",
            "stepsA": [{
                "height": "auto",
                "transition": "height 1000ms ease 0"
            }],
            "stepsB": [{
                "height": "88px",
                "transition": "transform 200 ease 0, height 1000ms ease 0"
            }]
        }, {
            "type": "click",
            "selector": ".button__expandablesection__icon",
            "descend": true,
            "preserve3d": true,
            "stepsA": [{
                "transition": "transform 500ms ease 0",
                "rotateX": "0deg",
                "rotateY": "0deg",
                "rotateZ": "180deg"
            }],
            "stepsB": [{
                "transition": "transform 500ms ease 0",
                "rotateX": "0deg",
                "rotateY": "0deg",
                "rotateZ": "0deg"
            }]
        }]
    }
}, {
    "slug": "expandablearea-expanded",
    "name": "expandableArea - expanded",
    "value": {
        "style": {
            "height": "auto"
        },
        "triggers": [{
            "type": "click",
            "stepsA": [{
                "height": "88px",
                "transition": "height 1000ms ease 0"
            }],
            "stepsB": [{
                "height": "auto",
                "transition": "transform 200 ease 0, height 1000ms ease 0"
            }]
        }, {
            "type": "click",
            "selector": ".button__expandablesection__icon--expanded",
            "descend": true,
            "preserve3d": true,
            "stepsA": [{
                "transition": "transform 500ms ease 0",
                "rotateX": "0deg",
                "rotateY": "0deg",
                "rotateZ": "180deg"
            }],
            "stepsB": [{
                "transition": "transform 500ms ease 0",
                "rotateX": "0deg",
                "rotateY": "0deg",
                "rotateZ": "0deg"
            }]
        }]
    }
}, {
    "slug": "analyse-modalclose",
    "name": "Analyse__modalCLOSE",
    "value": {
        "style": {},
        "triggers": [{
            "type": "click",
            "selector": ".analyse__modalcontents",
            "stepsA": [{
                "opacity": 0,
                "transition": "opacity 200 ease 0"
            }],
            "stepsB": []
        }, {
            "type": "click",
            "selector": ".analyse__modalbg",
            "stepsA": [{
                "wait": "250ms"
            }, {
                "opacity": 0,
                "transition": "opacity 200ms ease 0"
            }, {
                "display": "none"
            }],
            "stepsB": []
        }, {
            "type": "click",
            "stepsA": [{
                "opacity": 0,
                "transition": "opacity 200 ease 0"
            }, {
                "display": "none"
            }],
            "stepsB": []
        }]
    }
}, {
    "slug": "nav-logo-hover",
    "name": "Nav Logo Hover",
    "value": {
        "style": {},
        "triggers": [{
            "type": "hover",
            "stepsA": [{
                "opacity": 0.9,
                "transition": "transform 500ms ease 0, opacity 500ms ease 0",
                "scaleX": 1.1,
                "scaleY": 1.1,
                "scaleZ": 1
            }],
            "stepsB": [{
                "opacity": 1,
                "transition": "transform 500ms ease 0, opacity 500ms ease 0",
                "scaleX": 1,
                "scaleY": 1,
                "scaleZ": 1
            }]
        }]
    }
}, {
    "slug": "free-app-image-1-deactivate",
    "name": "Free App image 1 DEACTIVATE",
    "value": {
        "style": {},
        "triggers": [{
            "type": "scroll",
            "selector": ".freeappimage--01__mask",
            "stepsA": [{
                "opacity": 1,
                "transition": "opacity 1000ms ease 0"
            }],
            "stepsB": []
        }]
    }
}, {
    "slug": "free-app-01",
    "name": "Free App 01",
    "value": {
        "style": {},
        "triggers": [{
            "type": "scroll",
            "selector": ".freeapptext",
            "descend": true,
            "offsetBot": "35%",
            "preserve3d": true,
            "stepsA": [{
                "opacity": 1,
                "transition": "opacity 1000ms ease 0, transform 1000ms ease 0",
                "x": "0px",
                "y": "-50%",
                "z": "0px"
            }],
            "stepsB": [{
                "opacity": 0,
                "transition": "opacity 200 ease 0"
            }]
        }, {
            "type": "scroll",
            "selector": ".freeappimage--01__mask",
            "offsetBot": "55%",
            "stepsA": [{
                "opacity": 0,
                "transition": "opacity 1000ms ease 0"
            }],
            "stepsB": []
        }]
    }
}, {
    "slug": "free-app-02",
    "name": "Free App 02",
    "value": {
        "style": {},
        "triggers": [{
            "type": "scroll",
            "selector": ".freeapptext",
            "descend": true,
            "offsetBot": "20%",
            "preserve3d": true,
            "stepsA": [{
                "opacity": 1,
                "transition": "opacity 1000ms ease 0, transform 1000ms ease 0",
                "x": "0px",
                "y": "-50%",
                "z": "0px"
            }],
            "stepsB": [{
                "opacity": 0,
                "transition": "opacity 200 ease 0"
            }]
        }]
    }
}, {
    "slug": "free-app-03",
    "name": "Free App 03",
    "value": {
        "style": {},
        "triggers": [{
            "type": "scroll",
            "offsetBot": "20%",
            "stepsA": [{
                "opacity": 1,
                "transition": "opacity 1000ms ease 0, transform 1000ms ease 0",
                "x": "0px",
                "y": "-50%",
                "z": "0px"
            }],
            "stepsB": [{
                "opacity": 0,
                "transition": "opacity 200 ease 0, transform 200 ease 0",
                "x": "0px",
                "y": "0px",
                "z": "0px"
            }]
        }]
    }
}, {
    "slug": "free-app-04",
    "name": "Free App 04",
    "value": {
        "style": {},
        "triggers": [{
            "type": "scroll",
            "offsetBot": "50%",
            "stepsA": [{
                "opacity": 1,
                "transition": "opacity 1000ms ease 0, transform 1000ms ease 0",
                "x": "0px",
                "y": "-50%",
                "z": "0px"
            }],
            "stepsB": [{
                "opacity": 0,
                "transition": "opacity 200 ease 0"
            }]
        }]
    }
}, {
    "slug": "free-app-bottom-deactivate",
    "name": "Free App Bottom DEACTIVATE",
    "value": {
        "style": {},
        "triggers": [{
            "type": "scroll",
            "offsetTop": "0%",
            "stepsA": [{
                "opacity": 0,
                "transition": "opacity 200 ease 0"
            }, {
                "display": "none"
            }],
            "stepsB": []
        }]
    }
}, {
    "slug": "fadeinonscroll-left-01",
    "name": "FADEinONscroll_left--01",
    "value": {
        "style": {
            "opacity": 0,
            "x": "0px",
            "y": "20px",
            "z": "0px"
        },
        "triggers": [{
            "type": "scroll",
            "offsetTop": "25%",
            "offsetBot": "25%",
            "stepsA": [{
                "opacity": 1,
                "transition": "opacity 1000ms ease 0, transform 1000ms ease 0",
                "x": "0px",
                "y": "0px",
                "z": "0px"
            }],
            "stepsB": [{
                "opacity": 0,
                "transition": "transform 500ms ease 0, opacity 500ms ease 0",
                "x": "0px",
                "y": "20px",
                "z": "0px"
            }]
        }]
    }
}, {
    "slug": "fadeinonscroll-left-02",
    "name": "FADEinONscroll_left--02",
    "value": {
        "style": {
            "opacity": 0,
            "x": "0px",
            "y": "20px",
            "z": "0px"
        },
        "triggers": [{
            "type": "scroll",
            "offsetTop": "25%",
            "offsetBot": "25%",
            "stepsA": [{
                "wait": "500ms"
            }, {
                "opacity": 1,
                "transition": "opacity 1000ms ease 0, transform 1000ms ease 0",
                "x": "0px",
                "y": "0px",
                "z": "0px"
            }],
            "stepsB": [{
                "opacity": 0,
                "transition": "transform 500ms ease 0, opacity 500ms ease 0",
                "x": "0px",
                "y": "20px",
                "z": "0px"
            }]
        }]
    }
}, {
    "slug": "fadeinonscroll-left-03",
    "name": "FADEinONscroll_left--03",
    "value": {
        "style": {
            "opacity": 0,
            "x": "0px",
            "y": "20px",
            "z": "0px"
        },
        "triggers": [{
            "type": "scroll",
            "offsetTop": "25%",
            "offsetBot": "25%",
            "stepsA": [{
                "wait": "1000ms"
            }, {
                "opacity": 1,
                "transition": "opacity 1000ms ease 0, transform 1000ms ease 0",
                "x": "0px",
                "y": "0px",
                "z": "0px"
            }],
            "stepsB": [{
                "opacity": 0,
                "transition": "transform 500ms ease 0, opacity 500ms ease 0",
                "x": "0px",
                "y": "20px",
                "z": "0px"
            }]
        }]
    }
}, {
    "slug": "fadeinonscroll-left-04",
    "name": "FADEinONscroll_left--04",
    "value": {
        "style": {
            "opacity": 0,
            "x": "0px",
            "y": "20px",
            "z": "0px"
        },
        "triggers": [{
            "type": "scroll",
            "offsetTop": "25%",
            "offsetBot": "25%",
            "stepsA": [{
                "wait": "1500ms"
            }, {
                "opacity": 1,
                "transition": "opacity 1000ms ease 0, transform 1000ms ease 0",
                "x": "0px",
                "y": "0px",
                "z": "0px"
            }],
            "stepsB": [{
                "opacity": 0,
                "transition": "transform 500ms ease 0, opacity 500ms ease 0",
                "x": "0px",
                "y": "20px",
                "z": "0px"
            }]
        }]
    }
}, {
    "slug": "preloader-logo",
    "name": "Preloader__logo",
    "value": {
        "style": {},
        "triggers": [{
            "type": "load",
            "loopA": true,
            "stepsA": [{
                "transition": "transform 10s ease 0",
                "scaleX": 1.5,
                "scaleY": 1.5,
                "scaleZ": 1
            }],
            "stepsB": []
        }]
    }
}, {
    "slug": "home-sapianimation",
    "name": "home__sapiAnimation",
    "value": {
        "style": {},
        "triggers": [{
            "type": "scroll",
            "selector": ".sapi__bg",
            "offsetBot": "20%",
            "preserve3d": true,
            "stepsA": [{
                "x": "-50%",
                "y": "0px",
                "z": "0px"
            }, {
                "opacity": 1,
                "transition": "transform 1500ms ease 0, opacity 1500ms ease 0",
                "scaleX": 1.1,
                "scaleY": 1.1,
                "scaleZ": 1
            }],
            "stepsB": []
        }, {
            "type": "scroll",
            "selector": ".sapi__circle--1",
            "offsetBot": "20%",
            "preserve3d": true,
            "stepsA": [{
                "x": "-50%",
                "y": "0px",
                "z": "0px"
            }, {
                "wait": "500ms"
            }, {
                "opacity": 1,
                "transition": "transform 250ms ease 0, opacity 250ms ease 0",
                "scaleX": 1.05,
                "scaleY": 1.05,
                "scaleZ": 1
            }, {
                "transition": "transform 50ms ease 0",
                "scaleX": 1,
                "scaleY": 1,
                "scaleZ": 1
            }],
            "stepsB": []
        }, {
            "type": "scroll",
            "selector": ".sapi__circle--2",
            "offsetBot": "20%",
            "preserve3d": true,
            "stepsA": [{
                "wait": "1000ms"
            }, {
                "opacity": 1,
                "transition": "transform 250ms ease 0, opacity 250ms ease 0",
                "scaleX": 1.05,
                "scaleY": 1.05,
                "scaleZ": 1
            }, {
                "transition": "transform 50ms ease 0",
                "scaleX": 1,
                "scaleY": 1,
                "scaleZ": 1
            }],
            "stepsB": []
        }, {
            "type": "scroll",
            "selector": ".sapi__circle--3",
            "offsetBot": "20%",
            "preserve3d": true,
            "stepsA": [{
                "x": "-50%",
                "y": "0px",
                "z": "0px"
            }, {
                "wait": "1500ms"
            }, {
                "opacity": 1,
                "transition": "transform 250ms ease 0, opacity 250ms ease 0",
                "scaleX": 1.05,
                "scaleY": 1.05,
                "scaleZ": 1
            }, {
                "transition": "transform 50ms ease 0",
                "scaleX": 1,
                "scaleY": 1,
                "scaleZ": 1
            }],
            "stepsB": []
        }, {
            "type": "scroll",
            "selector": ".sapi__circle--4",
            "offsetBot": "20%",
            "preserve3d": true,
            "stepsA": [{
                "wait": "2000ms"
            }, {
                "opacity": 1,
                "transition": "transform 250ms ease 0, opacity 250ms ease 0",
                "scaleX": 1.05,
                "scaleY": 1.05,
                "scaleZ": 1
            }, {
                "transition": "transform 50ms ease 0",
                "scaleX": 1,
                "scaleY": 1,
                "scaleZ": 1
            }],
            "stepsB": []
        }, {
            "type": "scroll",
            "selector": ".sapi__text--1",
            "offsetBot": "20%",
            "stepsA": [{
                "wait": "500ms"
            }, {
                "opacity": 1,
                "transition": "opacity 750ms ease 0"
            }],
            "stepsB": []
        }, {
            "type": "scroll",
            "selector": ".sapi__text--2",
            "offsetBot": "20%",
            "stepsA": [{
                "wait": "1s"
            }, {
                "opacity": 1,
                "transition": "opacity 750ms ease 0"
            }],
            "stepsB": []
        }, {
            "type": "scroll",
            "selector": ".sapi__text--3",
            "offsetBot": "20%",
            "stepsA": [{
                "wait": "1500ms"
            }, {
                "opacity": 1,
                "transition": "opacity 750ms ease 0"
            }],
            "stepsB": []
        }, {
            "type": "scroll",
            "selector": ".sapi__text--4",
            "offsetBot": "20%",
            "stepsA": [{
                "wait": "2000ms"
            }, {
                "opacity": 1,
                "transition": "opacity 750ms ease 0"
            }],
            "stepsB": []
        }, {
            "type": "scroll",
            "selector": ".sapi__arrowcontainer",
            "offsetBot": "20%",
            "preserve3d": true,
            "stepsA": [{
                "wait": "2000ms"
            }, {
                "opacity": 1,
                "transition": "transform 2000ms ease 0, opacity 2000ms ease 0",
                "rotateX": "0deg",
                "rotateY": "0deg",
                "rotateZ": "0deg"
            }],
            "stepsB": []
        }]
    }
}, {
    "slug": "signup-pastoralunavailable",
    "name": "signUp_pastoralUnavailable",
    "value": {
        "style": {},
        "triggers": [{
            "type": "click",
            "selector": ".signup__unavailable",
            "stepsA": [{
                "opacity": 1,
                "height": "auto",
                "transition": "height 400ms ease 0, opacity 200 ease 0"
            }],
            "stepsB": [{
                "opacity": 0,
                "height": "0px",
                "transition": "height 200 ease 0, opacity 200 ease 0"
            }]
        }, {
            "type": "hover",
            "stepsA": [{
                "transition": "transform 200 ease 0",
                "scaleX": 1.2,
                "scaleY": 1.2,
                "scaleZ": 1
            }],
            "stepsB": [{
                "transition": "transform 200 ease 0",
                "scaleX": 1,
                "scaleY": 1,
                "scaleZ": 1
            }]
        }]
    }
}, {
    "slug": "sapi-mobiletext",
    "name": "sapi--mobileText",
    "value": {
        "style": {
            "opacity": 0
        },
        "triggers": [{
            "type": "scroll",
            "offsetBot": "20%",
            "stepsA": [{
                "opacity": 1,
                "transition": "opacity 1000ms ease 0"
            }],
            "stepsB": []
        }]
    }
}, {
    "slug": "sapi-mobilearrows",
    "name": "sapi--mobileArrows",
    "value": {
        "style": {
            "opacity": 0,
            "x": "0px",
            "y": "-20px",
            "z": "0px"
        },
        "triggers": [{
            "type": "scroll",
            "offsetBot": "20%",
            "stepsA": [{
                "opacity": 1,
                "transition": "transform 500ms ease 0, opacity 500ms ease 0",
                "x": "0px",
                "y": "0px",
                "z": "0px"
            }],
            "stepsB": []
        }]
    }
}, {
    "slug": "analyse-accordiontoggle",
    "name": "Analyse AccordionToggle",
    "value": {
        "style": {},
        "triggers": [{
            "type": "click",
            "selector": ".analyse__expandedtext",
            "descend": true,
            "stepsA": [{
                "height": "auto",
                "transition": "height 1000ms ease 0"
            }],
            "stepsB": [{
                "height": "0px",
                "transition": "height 1000ms ease 0"
            }]
        }, {
            "type": "click",
            "selector": ".analyse__accordionarrow",
            "descend": true,
            "preserve3d": true,
            "stepsA": [{
                "transition": "transform 300ms ease 0",
                "rotateX": "0deg",
                "rotateY": "0deg",
                "rotateZ": "180deg"
            }],
            "stepsB": [{
                "transition": "transform 300ms ease 0",
                "rotateX": "0deg",
                "rotateY": "0deg",
                "rotateZ": "0deg"
            }]
        }]
    }
}]);