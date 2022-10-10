<%@ Control Language="C#" AutoEventWireup="true" CodeFile="social-f.ascx.cs" Inherits="biz4afrika_controls_social_social" %>
<style>
    .talk1 {
        display: none;
    }

    @media screen and (max-width: 500px) {
        .talk2 {
            display: none;
        }

        .talk1 {
            display: table;
        }
    }

    @media screen and (max-width: 1090px) {
        .m-social {
            width: 97% !important;
            margin-left: auto !important;
            margin-right: auto !important;
        }
    }
</style>
<div data-grid="col-12" style="background: #fff; width: 100%; padding-top: 40px;">

    <div class="talk1" style="padding: 10px; background: #575757; color: #fff; cursor: pointer; margin: 0 auto;"
        data-js-dialog-show="questions" title="Questions? Talk to an expert">
        Questions? Talk to an expert
    </div>

    <div class="m-social f-horizontal f-share" style="position: relative;" itemscope="" itemtype="https://schema.org/Organization">
        <span>Follow us</span>
        <ul>
            <li>
                <a data-m="{&quot;pid&quot;:&quot;h:716c79&quot;,&quot;id&quot;:&quot;n1m1r5a2&quot;,&quot;sN&quot;:1,&quot;aN&quot;:&quot;m1r5a2&quot;}" itemprop="sameAs" href="https://www.facebook.com/Microsoft" aria-label="follow microsoft on facebook">
                    <picture>
                        <source type="image/svg+xml" srcset="//www.microsoft.com/onerfstatics/marketingsites-neu-prod/_h/2532198d/coreui.statics/images/social/facebook.svg">
                        <img src="//www.microsoft.com/onerfstatics/marketingsites-neu-prod/_h/85288795/coreui.statics/images/social/facebook.png" alt=" " title=" ">
                    </picture>
                </a>
            </li>
            <li>
                <a data-m="{&quot;pid&quot;:&quot;h:c15e05d3&quot;,&quot;id&quot;:&quot;n2m1r5a2&quot;,&quot;sN&quot;:2,&quot;aN&quot;:&quot;m1r5a2&quot;}" itemprop="sameAs" href="https://twitter.com/Microsoft" aria-label="follow microsoft on twitter">
                    <picture>
                        <source type="image/svg+xml" srcset="//www.microsoft.com/onerfstatics/marketingsites-neu-prod/_h/6f40299c/coreui.statics/images/social/twitter.svg">
                        <img src="//www.microsoft.com/onerfstatics/marketingsites-neu-prod/_h/93690392/coreui.statics/images/social/twitter.png" alt=" " title=" ">
                    </picture>
                </a>
            </li>
            <li>
                <a data-m="{&quot;pid&quot;:&quot;h:f45d7d2d&quot;,&quot;id&quot;:&quot;n3m1r5a2&quot;,&quot;sN&quot;:3,&quot;aN&quot;:&quot;m1r5a2&quot;}" itemprop="sameAs" href="https://www.linkedin.com/company/microsoft" aria-label="follow microsoft on linkedin">
                    <picture>
                        <source type="image/svg+xml" srcset="//www.microsoft.com/onerfstatics/marketingsites-neu-prod/_h/413bd4a8/coreui.statics/images/social/linkedin.svg">
                        <img src="//www.microsoft.com/onerfstatics/marketingsites-neu-prod/_h/b23f9ba2/coreui.statics/images/social/linkedin.png" alt=" " title=" ">
                    </picture>
                </a>
            </li>
            <li>
                <a data-m="{&quot;pid&quot;:&quot;h:4e3cfeda&quot;,&quot;id&quot;:&quot;n4m1r5a2&quot;,&quot;sN&quot;:4,&quot;aN&quot;:&quot;m1r5a2&quot;}" itemprop="sameAs" href="https://www.youtube.com/channel/UCqJT0GdOROGqEIoC535E64w" aria-label="follow microsoft on youtube">
                    <picture>
                        <source type="image/svg+xml" srcset="//www.microsoft.com/onerfstatics/marketingsites-neu-prod/_h/2d505657/coreui.statics/images/social/youtube.svg">
                        <img src="//www.microsoft.com/onerfstatics/marketingsites-neu-prod/_h/c79952ca/coreui.statics/images/social/youtube.png" alt=" " title=" ">
                    </picture>
                </a>
            </li>
        </ul>

        <div class="talk2" style="padding: 10px; background: #575757; color: #fff; float: right; cursor: pointer; position: absolute; right: 0; bottom: -4px;"
            data-js-dialog-show="questions" title="Questions? Talk to an expert">
            Questions? Talk to an expert
        </div>

    </div>


</div>

<div class="c-dialog" id="questions" aria-hidden="true">
    <div role="presentation" tabindex="-1"></div>
    <div role="dialog" aria-label="Default" tabindex="-1">
        <h1 class="c-heading-3">Questions? Talk to an expert</h1>
        <br />
        We're here to help 24/7<br />
        <br />
        <a href="#" target="_blank" style="text-decoration: underline;" title="Get technical or download support on the site">Get technical or download support on the site</a><br />
        <br />
        First time on Biz4Afrika? <a style="text-decoration: underline;" href="#" target="_blank" title="Here’s how to start">Here’s how to start</a><br />
        <br />
        <a href="#" style="text-decoration: underline;" target="_blank" title="How to get the best out of Biz4Afrika for your business">How to get the best out of Biz4Afrika for your business</a>

        <div class="c-group">
            <button style="float: none; margin: 0 auto; width: 100px; display: table; margin-top: 23px;"
                class="c-button" type="submit" data-js-dialog-hide="" aria-label="Close dialog">
                Back</button>
        </div>
    </div>
</div>
