GoodreadsApp = (function (Backbone, _, $) {
    var GoodreadsModel = Backbone.Model.extend({});

    var GoodreadsCollection = Backbone.Collection.extend({
        model: GoodreadsModel
    });

    var GoodreadsView = Backbone.View.extend({
        el: $('.goodreads-widget'),

        initialize: function () {
            this.collection.bind("reset", this.render, this);
        },

        render: function () {
            var data = this.collection.models[0].attributes;
            if (data) {
                var $template = $('#goodreads-template');
                var goodreadsHtml = $template.tmpl(data);
                $(this.el).html(goodreadsHtml);
            }
        }
    });

    var goodreadsApp = function (initialModels) {
        this.start = function () {
            this.models = new GoodreadsCollection();
            this.myView = new GoodreadsView({ collection: this.models });
            this.models.reset(initialModels);
        };
    };

    return goodreadsApp;
})(Backbone, _, jQuery);