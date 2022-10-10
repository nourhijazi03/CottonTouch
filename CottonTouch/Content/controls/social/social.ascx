<%@ Control Language="C#" AutoEventWireup="true" CodeFile="social.ascx.cs" Inherits="new_controls_social_social" %>
<div style="margin: -24px auto -32px;">
    <div class="m-social f-horizontal" itemscope="" itemtype="https://schema.org/Organization">
        <ul style="text-align: right; width: 100%;">
            <li style="display: inline-block; float: right;">
                <a style="margin-right: 0px; cursor: pointer;" itemprop="sameAs" aria-label="Share on LinkedIn" onclick="return link_click()" target="_blank">
                    <picture>
                    <source type="image/svg+xml" srcset="//statics-mwf-eus-ms-com.akamaized.net/_h/mwfhash/mwf.app/images/components/social/linkedin.svg"></source>
                    <img src="//statics-mwf-eus-ms-com.akamaized.net/_h/mwfhash/mwf.app/images/components/social/twitter.png" alt="Twitter logo">
                </picture>
                </a>
            </li>
            <li style="display: inline-block; float: right;">
                <a itemprop="sameAs" aria-label="Share on Skype" style="cursor: pointer;" class='skype-share' data-href='' data-lang='' data-text='' target="_blank">
                    <picture>
                    <source type="image/svg+xml" srcset="//statics-mwf-eus-ms-com.akamaized.net/_h/mwfhash/mwf.app/images/components/social/skype.svg"></source>
                    <img src="//statics-mwf-eus-ms-com.akamaized.net/_h/mwfhash/mwf.app/images/components/social/twitter.png" alt="Twitter logo">
                </picture>
                </a>
            </li>
            <li style="display: inline-block; float: right;">
                <a itemprop="sameAs" aria-label="Share on Twitter" style="cursor: pointer;" onclick="return twt_click()" target="_blank">
                    <picture>
                    <source type="image/svg+xml" srcset="//statics-mwf-eus-ms-com.akamaized.net/_h/mwfhash/mwf.app/images/components/social/twitter.svg"></source>
                    <img src="//statics-mwf-eus-ms-com.akamaized.net/_h/mwfhash/mwf.app/images/components/social/twitter.png" alt="Twitter logo">
                </picture>
                </a>
            </li>
            <li style="display: inline-block; float: right;">
                <a itemprop="sameAs" aria-label="Share on Facebook" style="cursor: pointer;" onclick="return fbs_click()" target="_blank" class="x-hidden-focus">
                    <picture>
                    <source type="image/svg+xml" srcset="//statics-mwf-eus-ms-com.akamaized.net/_h/mwfhash/mwf.app/images/components/social/facebook.svg"></source>
                    <img src="//statics-mwf-eus-ms-com.akamaized.net/_h/mwfhash/mwf.app/images/components/social/facebook.png" alt="Facebook logo">
                </picture>
                </a>
            </li>
            <li style="float: right; display: inline-block; line-height: 28px; margin-right: 10px; font-size: 19px;" class="x-hidden-focus">Share
                </li>
        </ul>
    </div>
</div>
