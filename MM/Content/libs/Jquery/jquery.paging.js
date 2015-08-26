﻿/**
 * This jQuery plugin displays pagination links inside the selected elements.
 * http://www.zhangxinxu.com/jq/pagination_zh/demo.html 在此基础上定制 
 * @version 1.2 
 * @param {int} maxentries Number of entries to paginate
 * @param {Object} opts Several options (see README for documentation)
 * @return {Object} jQuery Object
 */

//注意 此分页插件页数从0开始索引
jQuery.fn.pagination = function (maxentries, opts) {
    opts = jQuery.extend({
        items_per_page: 20,
        num_display_entries: 6,
        current_page: 0,
        num_edge_entries: 1,
        link_to: "javascript:void(0)",
        prev_text: "&lt;",
        next_text: "&gt;",
        ellipse_text: "...",
        prev_show_always: true,
        next_show_always: true,
        callback: function () { return false; }
    }, opts || {});

    return this.each(function () {
        /**
		 * 计算最大分页显示数目
		 */
        function numPages() {
            return Math.ceil(maxentries / opts.items_per_page);
        }
        /**
		 * 极端分页的起始和结束点，这取决于current_page 和 num_display_entries.
		 * @返回 {数组(Array)}
		 */
        function getInterval() {
            var ne_half = Math.ceil(opts.num_display_entries / 2);
            var np = numPages();
            opts.PageTotal = np;
            var upper_limit = np - opts.num_display_entries;
            var start = current_page > ne_half ? Math.max(Math.min(current_page - ne_half, upper_limit), 0) : 0;
            var end = current_page > ne_half ? Math.min(current_page + ne_half, np) : Math.min(opts.num_display_entries, np);
            return [start, end];
        }

        /**
		 * 分页链接事件处理函数
		 * @参数 {int} page_id 为新页码
		 */
        function pageSelected(page_id, evt) {
            current_page = page_id;
            drawLinks();
            var continuePropagation = opts.callback(page_id, panel);
            if (!continuePropagation) {
                if (evt.stopPropagation) {
                    evt.stopPropagation();
                }
                else {
                    evt.cancelBubble = true;
                }
            }
            return continuePropagation;
        }

        /**
		 * 此函数将分页链接插入到容器元素中
		 */
        function drawLinks() {
            panel.empty();
            var interval = getInterval();
            var np = numPages();
            // 这个辅助函数返回一个处理函数调用有着正确page_id的pageSelected。
            var getClickHandler = function (page_id) {
                return function (evt) { return pageSelected(page_id, evt); }
            }
            //辅助函数用来产生一个单链接(如果不是当前页则产生span标签)
            var appendItem = function(page_id, appendopts) {
                page_id = page_id < 0 ? 0 : (page_id < np ? page_id : np - 1); // 规范page id值
                appendopts = jQuery.extend({ text: page_id + 1, classes: "" }, appendopts || {});
                var lnk = null;
                if (page_id == current_page) {
                    if (appendopts.text == opts.prev_text || appendopts.text == opts.next_text) {//上一页 下一页
                        lnk = jQuery("<span class='prev no'>" + (appendopts.text) + "</span>");
                    } else {
                        lnk = jQuery("<span class='num active'>" + (appendopts.text) + "</span>");
                    }
                } else {
                    lnk = jQuery("<a >" + (appendopts.text) + "</a>")
                        .bind("click", getClickHandler(page_id))
                        .attr('href', opts.link_to.replace(/__id__/, page_id));
                }
                if (appendopts.classes) {
                    lnk.addClass(appendopts.classes);
                }
                panel.append(lnk);
            };
            // 产生"Previous"-链接
            if (opts.prev_text && (current_page > 0 || opts.prev_show_always)) {
                appendItem(current_page - 1, { text: opts.prev_text, classes: "prev" });
            }
            // 产生起始点
            if (interval[0] > 0 && opts.num_edge_entries > 0) {
                var end = Math.min(opts.num_edge_entries, interval[0]);
                for (var i = 0; i < end; i++) {
                    appendItem(i, { classes: "num" });
                }
                if (opts.num_edge_entries < interval[0] && opts.ellipse_text) {
                    jQuery("<span class='more'>" + opts.ellipse_text + "</span>").appendTo(panel);
                }
            }
            // 产生内部的些链接
            for (var i = interval[0]; i < interval[1]; i++) {
                appendItem(i, {  classes: "num" });
            }
            // 产生结束点
            if (interval[1] < np && opts.num_edge_entries > 0) {
                if (np - opts.num_edge_entries > interval[1] && opts.ellipse_text) {
                    jQuery("<span class='more'>" + opts.ellipse_text + "</span>").appendTo(panel);
                }
                var begin = Math.max(np - opts.num_edge_entries, interval[1]);
                for (var i = begin; i < np; i++) {
                    appendItem(i, { classes: "num" });
                }

            }
            // 产生 "Next"-链接
            if (opts.next_text && (current_page < np - 1 || opts.next_show_always)) {
                appendItem(current_page + 1, { text: opts.next_text, classes: "next" });
            }


            //产生页数说明和跳转
            jQuery("<span class='total'>共" + opts.PageTotal + "页，到第</span>").appendTo(panel);
            jQuery("<input type='text' name='txtGoTo'>").appendTo(panel);
            jQuery("<span class='total'>页</span>").appendTo(panel);
            jQuery("<a class='go'>GO</a>").appendTo(panel);
            jQuery("<span class='total'>每页" + opts.items_per_page + "条，共" + maxentries + "条</span>").appendTo(panel);
           

        }
       
        //从选项中提取current_page
        var current_page = opts.current_page;
        //创建一个显示条数和每页显示条数值
        maxentries = (!maxentries || maxentries < 0) ? 1 : maxentries;
        opts.items_per_page = (!opts.items_per_page || opts.items_per_page < 0) ? 1 : opts.items_per_page;
        //存储DOM元素，以方便从所有的内部结构中获取
        var panel = jQuery(this);
        // 获得附加功能的元素
        this.selectPage = function(page_id) { pageSelected(page_id); };
        this.prevPage = function() {
            if (current_page > 0) {
                pageSelected(current_page - 1);
                return true;
            } else {
                return false;
            }
        };
        this.nextPage = function() {
            if (current_page < numPages() - 1) {
                pageSelected(current_page + 1);
                return true;
            } else {
                return false;
            }
        };
        // 所有初始化完成，绘制链接
        drawLinks();
       
        //绑定跳转事件
        $(this).on("click",".go", function (e) {
            var str = $(this).closest(".page").find("input[name=txtGoTo]").val();
            var pageIndex = parseInt(str);
            if (pageIndex && pageIndex > 0 && pageIndex <= Math.ceil(maxentries / opts.items_per_page)) {
                pageSelected(pageIndex - 1, e);
            }
        });

        // 回调函数 对外的页数索引从0开始
        opts.callback(current_page, this);
    });
}

