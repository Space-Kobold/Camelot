#!/usr/bin/env pwsh

# SPDX-FileCopyrightText: 2017-2025 Space Wizards Federation and Contributors <https://github.com/space-wizards/space-station-14>
#
# SPDX-License-Identifier: LicenseRef-MIT-SpaceWizards

[cmdletbinding()]

param(
    [Parameter(Mandatory=$true)]
    [DateTime]$since,

    [Nullable[DateTime]]$until,

    [Parameter(Mandatory=$true)]
    [string]$repo);

$r = @()

$page = 1

$qParams = @{
    "since" = $since.ToString("o");
    "per_page" = 100
    "page" = $page
}

if ($until -ne $null) {
    $qParams["until"] = $until.ToString("o")
}

$url = "https://api.github.com/repos/{0}/commits" -f $repo



while ($null -ne $url)
{
    $resp = Invoke-WebRequest $url -UseBasicParsing -Body $qParams

    if($resp.Content.Length -eq 2) {
        break
    }

    $page += 1
    $qParams["page"] = $page
    

    $j = ConvertFrom-Json $resp.Content
    $r += $j
}

return $r
