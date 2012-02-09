using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;

namespace AviBlog.Core.Helpers
{
    public static class CheckBoxListHelper
    {
        /// <summary>
        /// Checks the box for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="html">The HTML.</param>
        /// <param name="expression">The expression.</param>
        /// <returns>Checkbox</returns>
        public static MvcHtmlString CheckBoxForCustom<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            return CheckBoxForCustom(html, expression, new RouteDirection());
        }


        /// <summary>
        /// Checks the box for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="html">The HTML.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>Checkbox</returns>
        public static MvcHtmlString CheckBoxForCustom<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes)
        {

            return CheckBoxForCustom(html, expression, htmlAttributes, "");
        }

        /// <summary>
        /// Checks the box for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="html">The HTML.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="checkedValue">The checked value.</param>
        /// <returns>Checkbox</returns>
        public static MvcHtmlString CheckBoxForCustom<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes, string checkedValue)
        {

            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);

            var tag = new TagBuilder("input");
            tag.Attributes.Add("type", "checkbox");
            tag.Attributes.Add("name", metadata.PropertyName);
            if (!string.IsNullOrEmpty(checkedValue))
            {
                tag.Attributes.Add("value", checkedValue);
            }
            else
            {
                tag.Attributes.Add("value", metadata.Model.ToString());
            }

            if (htmlAttributes != null)
            {
                tag.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            }

            if (metadata.Model.ToString() == checkedValue)
            {
                tag.Attributes.Add("checked", "checked");
            }
            return MvcHtmlString.Create(tag.ToString(TagRenderMode.SelfClosing));
        }
    }
}